using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using zolive_api.Models;
using zolive_api.Services.Interface;
using zolive_api.src;
using zolive_db.Models;
using zolive_model.Models;

namespace zolive_api.Controllers
{
    [Route("appapi/[controller].[action]")]
    [ApiController]
    public class LivepkController : Controller
    {
        private readonly newliveContext context;
        private readonly ILiveService _liveService;
        private readonly ICommonService _commonService;
        public LivepkController(newliveContext context, ILiveService liveService, ICommonService commonService)
        {
            this.context = context;
            _commonService = commonService;
            _liveService = liveService;
        }

        [ActionName("checkLive")]
        [HttpGet]
        public async Task<ActionResult> checkLive(string? lan, ulong uid, string token, ulong liveuid, string stream, string uid_stream)
        {
            CacheManager cacheManager = new CacheManager();
            BaseResult result = new BaseResult();

            result.msg = "";
            result.debug = new Debug { sqls = new List<object>(), stack = new List<object>(), version = "1.4.2" };
            result.ret = 200;
            ResultBaseInfo rs = new ResultBaseInfo() { code = 0, msg = "", info = new List<dynamic>() };
            var info = await _liveService.CheckLivePK(stream);
            if (!info)
            {
                rs.code = 1001;
                rs.msg = "对方已关播";
                if (lan == "En") rs.msg = "The other side has closed the broadcast";
                if (lan == "Nam") rs.msg = "Đã đóng phát";
                result.data = rs;
                return Json(result);
            }
            var configpri = await _commonService.getConfigPri();
            var nowtime = Utils.time();
            var live_sdk = configpri.live_sdk.Value;
            var play_url = "";
            if (live_sdk == "1")
            {
                var bizid = configpri.tx_bizid.Value;
                var tx_acc_key = configpri.tx_acc_key.Value;
                var pull = configpri.tx_pull.Value;

                var now_time2 = nowtime + 3 * 60 * 60;
                var txTime = Utils.DecimalToHex(now_time2);
                var live_code = uid_stream;
                var txSecret2 = Utils.MD5Hash(tx_acc_key + live_code + txTime);
                var safe_url2 = "?txSecret=" + txSecret2 + "&txTime=" + txTime;
                play_url = "rtmp://" + pull + "/live/" + live_code + safe_url2 + "&bizid=" + bizid;
            }
            else if (configpri.cdn_switch.Value == "5")
            {
                var liveinfo = await context.CmfLives.FirstOrDefaultAsync(x => x.Stream == uid_stream);
                if (liveinfo != null)
                {
                    play_url = liveinfo.Pull;
                }

            }
            else
            {
                play_url = await _commonService.PrivateKeyA("rtmp", uid_stream, 0);
            }

            var body = new
            {
                pull = play_url
            };
            rs.info.Add(body);
            result.data = rs;
            return Ok(result);
        }
    }
}
