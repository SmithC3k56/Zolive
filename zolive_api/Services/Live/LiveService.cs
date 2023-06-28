using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using zolive_api.Models.Live;
using zolive_api.Models.User;
using zolive_api.Services.Interface;
using zolive_api.src;
using zolive_db.Models;

namespace zolive_api.Services.Live
{
    public class LiveService : ILiveService
    {
        private readonly newliveContext context;
        private readonly IHomeService _homeService;
        private readonly CacheManager cacheManager = new CacheManager();
        private readonly IConfiguration _config;
        private readonly ICommonService _commonService;
        public LiveService(ICommonService commonService, newliveContext context, IHomeService homeService, IConfiguration config)
        {
            this._commonService = commonService;
            this._config = config;
            this.context = context;
            this._homeService = homeService;
        }
        public async Task<bool> CheckLivePK(string stream)
        {
            var isexit = await context.CmfLives.AnyAsync(x => x.Islive == 1 && x.Isvideo == false && x.Stream == stream);
            if (isexit) return true;

            return false;
        }
        public async Task<SendBarrageModel> sendBarrage(ulong uid, ulong liveuid, string stream, ulong giftid, int giftcount, string content)
        {
            var configpri = _commonService.getConfigPri().Result;
            var giftinfo = new
            {
                giftname = "Barrage",
                gifticon = "",
                needcoin = configpri.barrage_fee.Value
            };
            ulong total = ulong.Parse(giftinfo.needcoin) * giftcount;
            if (total < 0) return new SendBarrageModel();//1002
            var addtime = Utils.time();
            short action = 2;
            ulong showid = 0;
            if (total > 0)
            {
                var type = 0;
                var ifok = await context.CmfUsers1.FirstOrDefaultAsync(x => x.Id == uid && x.Coin >= total);
                if (ifok == null) return new SendBarrageModel();//1001
                ifok.Coin -= (ulong)total;
                ifok.Consumption += (ulong)total;
                context.CmfUsers1.Update(ifok);
                //   await context.SaveChangesAsync(); 
                var istouid = await context.CmfUsers1.FirstOrDefaultAsync(x => x.Id == liveuid);
                if (istouid == null) return new SendBarrageModel();//1003
                istouid.Votes += total;
                istouid.Votestotal += (ulong)total;
                context.CmfUsers1.Update(istouid);

                var stream2 = stream.Split("_");
                showid = ulong.Parse(stream2[1] ?? "0");
                var insert_votes = new CmfUserVoterecord()
                {
                    Type = 1,
                    Action = action,
                    Uid = liveuid,
                    Fromid = (long)uid,
                    Actionid = (long)giftid,
                    Nums = giftcount,
                    Total = total,
                    Showid = showid,
                    Votes = total,
                    Addtime = addtime

                };

                context.CmfUserVoterecords.Add(insert_votes);
                var insert = new CmfUserCoinrecord()
                {
                    Type = type,
                    Action = action,
                    Uid = uid,
                    Touid = liveuid,
                    Giftid = giftid,
                    Giftcount = giftcount,
                    Totalcoin = total,
                    Showid = showid,
                    Addtime = addtime
                };
                context.CmfUserCoinrecords.Add(insert);
                await context.SaveChangesAsync();
            }
            var userinfo2 = await context.CmfUsers1.Where(x => x.Id == uid).Select(x => new
            {
                consumption = x.Consumption,
                coin = x.Coin
            }).FirstOrDefaultAsync();

            if (userinfo2 == null) return new SendBarrageModel();

            var level = _commonService.getLevel(userinfo2.consumption).Result;
            var votestotal = getVotes(liveuid).Result;
            await cacheManager.DeleteCache("userinfo_" + uid);
            await cacheManager.DeleteCache("userinfo_" + liveuid);

            var barragetoken = Utils.MD5Hash(Utils.MD5Hash(action.ToString() + uid + liveuid + giftid + giftcount + total + showid + addtime + Utils.rand(100, 999)));

            var result = new SendBarrageModel()
            {
                uid = uid,
                content = content,
                giftid = giftid,
                giftcount = giftcount,
                totalcoin = total,
                giftname = giftinfo.giftname,
                gifticon = giftinfo.gifticon,
                level = level,
                coin = userinfo2.coin,
                votestotal = votestotal,
                barragetoken = barragetoken
            };
            return result;
        }

        public async Task getUserList(string lan, ulong liveuid, string stream, int p = 1)
        {
            if (p < 1) p = 1;
            var pnum = 20;
            var start = (p - 1) * pnum;
            var uidlist = cacheManager.zRevRangeWithScore("user_" + stream, start, -1, pnum);
            foreach (var v in uidlist)
            {

                var userinfo = await _homeService.getUserInfo(lan, ulong.Parse(v.Element.ToString()));
            }



        }
        public async Task<int> checkLiveing(ulong uid, string stream)
        {
            var info = await context.CmfLives.AnyAsync(x => x.Uid == uid && x.Stream == stream);
            if (info) return 1;
            return 0;
        }
        public async Task<CmfJackpot> getJackpotInfo()
        {
            var jackpotinfo = await context.CmfJackpots.Where(x => x.Id == 1).FirstAsync();
            return jackpotinfo;
        }
        public async Task<string?> getJackpotSet()
        {
            var key = "jackpotset";
            var config = cacheManager.GetCacheString(key);
            if (config == null)
            {
                config = await context.CmfOptions.Where(x => x.OptionName == "jackpot").Select(x => x.OptionValue).FirstAsync();
                if (config != null)
                {
                    await cacheManager.SetCacheString(key, config);
                }
            }
            return config;
        }
        public async Task<int> getGuardNums(ulong liveuid)
        {
            var nowtime = Utils.time();
            var nums = await context.CmfGuardUsers.Where(x => x.Liveuid == liveuid && x.Addtime > nowtime).CountAsync();
            return nums;
        }
        public async Task<ulong> getVotes(ulong liveuid)
        {
            var userinfo = await context.CmfUsers1.Where(x => x.Id == liveuid).Select(x => x.Votestotal).FirstOrDefaultAsync();
            return userinfo;
        }
        public async Task<int> createRoom(ulong uid, CmfLive data)
        {
            try
            {
                data.Ishot = false;
                data.Isrecommend = false;
                var userinfo = await context.CmfUsers1.Where(x => x.Id == uid).Select(x => new
                {
                    ishot = x.Ishot,
                    isrecommend = x.Isrecommend
                }).FirstOrDefaultAsync();
                if (userinfo != null)
                {
                    data.Ishot = userinfo.ishot ?? false;
                    data.Isrecommend = userinfo.isrecommend;
                }
                var isexist = await context.CmfLives.FirstOrDefaultAsync(x => x.Uid == uid);
                if (isexist != null)
                {
                    if (isexist.Isvideo == false && isexist.Islive == 1)
                    {
                        await stopRoom(uid, isexist.Stream);
                        await context.CmfLives.AddAsync(data);
                    }
                    else
                    {
                        context.CmfLives.Update(data);
                    }
                }
                else
                {
                    await context.CmfLives.AddAsync(data);
                }
                await context.SaveChangesAsync();
                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }

        public async Task<int> stopRoom(ulong uid, string stream)
        {
            var info = await context.CmfLives.Where(x => x.Uid == uid && x.Stream == stream && x.Islive == 1).Select(x => new CmfLiveRecord()
            {
                Uid = x.Uid,
                Showid = x.Showid,
                Starttime = (long)x.Starttime,
                Title = x.Title,
                Province = x.Province,
                City = x.City,
                Stream = x.Stream,
                Lng = x.Lng,
                Lat = x.Lat,
                Type = x.Type,
                TypeVal = x.TypeVal,
                Liveclassid = x.Liveclassid
            }).FirstOrDefaultAsync();

            var pathRoot = _config.GetValue<string>("API_ROOT");
            var path = pathRoot + "Runtime/stopRoom_" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
            var content = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " 提交参数信息 info:" + JsonConvert.SerializeObject(info) + "\r\n";
            await Utils.file_put_contents(path, content, "FILE_APPEND");
            if (info != null)
            {
                try
                {
                    var isdel = await context.CmfLives.Where(x => x.Uid == uid).FirstOrDefaultAsync();
                    if (isdel != null)
                    {
                        context.CmfLives.Remove(isdel);
                        await context.SaveChangesAsync();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return 0;//0 
                }

                var nowtime = Utils.time();
                info.Endtime = nowtime;
                info.Time = Utils.UnixTimeToDateTime(info.Showid).ToString("yyyy-MM-dd");
                var votes = await context.CmfUserVoterecords.Where(x => x.Uid == uid && x.Showid == (ulong)info.Showid).SumAsync(x => x.Total);
                info.Votes = votes.ToString();
                var nums = await cacheManager.ZCard("user_" + stream);
                await cacheManager.DeleteHash("livelist", uid.ToString());
                await cacheManager.DeleteCache(uid + "_zombie");
                await cacheManager.DeleteCache(uid + "_zombie_uid");
                await cacheManager.DeleteCache("attention_" + uid);
                await cacheManager.DeleteCache("user_" + stream);

                nums = await cacheManager.SCard(info.Uid + "_node");

                await cacheManager.DeleteCache(info.Uid + "_cc");
                await cacheManager.DeleteCache(info.Uid + "_node");

                info.Nums = (uint)nums;
                await context.CmfLiveRecords.AddAsync(info);
                await context.SaveChangesAsync();
                var path2 = pathRoot + "/Runtime/stopRoom_" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
                var content2 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " 提交参数信息 result:" + JsonConvert.SerializeObject(info.Id) + "\r\n";
                await Utils.file_put_contents(path2, content2, "FILE_APPEND");

                var list2 = await context.CmfLiveShuts.Where(x => x.Liveuid == uid && x.Showid != 0).Select(x => x.Uid).ToListAsync();
                foreach (var v in list2)
                {
                    await cacheManager.DeleteHash(uid + "shutup", v.ToString());
                }

                var game = await context.CmfGames.Where(x => x.Stream == stream && x.Liveuid == uid && x.State == 0).FirstOrDefaultAsync();

                if (game != null)
                {
                    var total = await context.CmfGamerecords.Where(x => x.Gameid == game.Id)
                    .GroupBy(x => x.Uid).Select(g => new
                    {
                        uid = g.Key,
                        total = g.Sum(x => x.Coin1 + x.Coin2 + x.Coin3 + x.Coin4 + x.Coin5 + x.Coin6)
                    }).ToListAsync();

                    foreach (var v in total)
                    {
                        var user = await context.CmfUsers1.Where(x => x.Id == v.uid).FirstOrDefaultAsync();
                        if (user != null)
                        {
                            user.Coin += (ulong)(v.total ?? 0);
                            context.CmfUsers1.Update(user);

                            var userCoinRecord = new CmfUserCoinrecord()
                            {
                                Type = 1,
                                Action = 20,
                                Uid = v.uid,
                                Touid = v.uid,
                                Giftid = game.Id,
                                Giftcount = 1,
                                Totalcoin = (ulong)(v.total ?? 0),
                                Showid = 0,
                                Addtime = nowtime

                            };
                            await context.CmfUserCoinrecords.AddAsync(userCoinRecord);
                        }
                        var gamess = await context.CmfGames.Where(x => x.Id == game.Id).FirstOrDefaultAsync();
                        if (gamess != null)
                        {
                            gamess.State = 3;
                            gamess.Endtime = Utils.time();
                            context.CmfGames.Update(gamess);
                        }
                        await context.SaveChangesAsync();
                        var brandToken = stream + "_" + game.Action + "_" + game.Starttime + "_Game";
                        await cacheManager.DeleteCache(brandToken);
                    }

                }
            }

            return 1;
        }


        public async Task<bool> isAuth(ulong uid)
        {
            var status = await context.CmfUserAuths.Where(a => a.Uid == uid).FirstOrDefaultAsync();
            if (status != null && status.Status == true)
            {
                return true;
            }
            return false;
        }
        public async Task<int> checkBan(ulong uid)
        {
            var isexist = await context.CmfLiveBans.Where(x => x.Liveuid == uid).FirstOrDefaultAsync();
            if (isexist != null)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public async Task<int> setReport(ulong uid, ulong touid, string content)
        {
            try
            {

                CmfReport data = new CmfReport()
                {
                    Uid = uid,
                    Touid = touid,
                    Content = content
                };
                await context.CmfReports.AddAsync(data);
                await context.SaveChangesAsync();
                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }
        public async Task<List<CmfReportClassify>> getReportClass()
        {
            List<CmfReportClassify> rs = await context.CmfReportClassifies.OrderByDescending(x => x.ListOrder).ToListAsync();
            return rs;
        }
        public async Task<CmfAgentCode?> getCode(ulong uid)
        {
            var ageninfo = await context.CmfAgentCodes.Where(x => x.Uid == uid).FirstOrDefaultAsync() ?? new CmfAgentCode();
            return ageninfo;
        }
        public async Task<GetAdminListModel> getAdminList(string lan, ulong liveuid)
        {
            var rs = await context.CmfLiveManagers.Where(x => x.Liveuid == liveuid).Select(x => x.Uid).ToListAsync();
            var result = new GetAdminListModel() { list = new List<UserInfo>(), nums = 0, total = 0 };
            foreach (var v in rs)
            {
                var userinfo = await _homeService.getUserInfo(lan, v);
                if (userinfo != null) result.list.Add(userinfo);
            }
            result.nums = result.list.Count;
            result.total = 5;
            return result;
        }
        public async Task<checkLiveResult?> checkLive(string? lan, ulong uid, ulong liveuid, string stream)
        {
            var rs = new checkLiveResult();
            var isexist = await context.CmfLiveKicks.Where(x => x.Uid == uid && x.Liveuid == liveuid).Select(x => x.Id).FirstOrDefaultAsync();

            if (isexist == 0)
            {
                return null;
            }
            var islive = await context.CmfLives.Where(x => x.Uid == uid && x.Stream == stream).Select(x => new
            {
                islive = x.Islive,
                type = x.Type,
                type_val = x.TypeVal,
                starttime = x.Starttime
            }).FirstOrDefaultAsync();

            if (islive == null || islive.islive == 0)
            {
                return null;
            }

            rs.type = 0;
            rs.type_val = "0";
            rs.type_msg = "";
            var userinfo = context.CmfUsers1.Where(x => x.Id == uid).FirstOrDefault();

            if (userinfo != null && userinfo.Issuper == true)
            {
                if (islive.type == 6)
                {
                    return null;
                }
                rs.type = 0;
                rs.type_val = "0";
                rs.type_msg = "";
                return rs;
            }

            var configpub = await _commonService.getConfigPub();

            if (islive.type == 1)
            {
                rs.type_msg = Utils.MD5Hash(islive.type_val);

            }
            else if (islive.type == 2)
            {
                rs.type_msg = "本房间为收费房间，需支付" + islive.type_val ?? "0" + configpub.name_coin ?? "";
                if (lan == "Nam")
                {
                    rs.type_msg = "Đây là phòng thu phí, giá vé " + islive.type_val ?? "0" + "xu";
                }
                else if (lan == "En")
                {
                    rs.type_msg = "This room is a charge room and needs to be paid " + islive.type_val ?? "0" + "coin";
                }

                rs.type_val = islive.type_val;
                var isexist2 = context.CmfUserCoinrecords.Where(x => x.Uid == uid && x.Touid == liveuid && x.Showid == (ulong)islive.starttime && x.Action == 6 && x.Type == 0).FirstOrDefault();
                if (isexist2 != null)
                {
                    rs.type = 0;
                    rs.type_val = "0";
                    rs.type_msg = "";
                }

            }
            else if (islive.type == 3)
            {
                rs.type_val = islive.type_val;
                rs.type_msg = "本房间为计时房间，每分钟需支付" + islive.type_val ?? "0" + configpub.name_coin ?? "";
                if (lan == "En")
                {
                    rs.type_msg = "This room is a chronograph room. You need to pay " + islive.type_val ?? "0" + "  coins per minute";
                }
                else if (lan == "Nam")
                {
                    rs.type_msg = "Căn phòng này là một căn phòng thợ máy. Bạn cần phải trả " + islive.type_val ?? "0" + islive.type_val + " đồng vàng mỗi phút.";
                }

            }

            return rs;

        }

    }
}
