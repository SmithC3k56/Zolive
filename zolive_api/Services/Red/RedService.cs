using Microsoft.EntityFrameworkCore;
using zolive_api.Models;
using zolive_api.Services.Interface;
using zolive_api.src;
using zolive_db.Models;

namespace zolive_api.Services.Red
{
  public class RedService : IRedService
  {

    private readonly newliveContext _context;
    public RedService(newliveContext context)
    {
      _context = context;
    }

    public async Task<ResultBaseInfo> sendRed(string lan, CmfRed data)
    {
      ResultBaseInfo rs = new ResultBaseInfo() { code = 0, msg = "发送成功", info = new List<CmfRed>() };
      if (lan == "En") rs.msg = "Sent successfully";
      if (lan == "Nam") rs.msg = "Gửi thành công";

      var uid = data.Uid;
      var total = data.Coin;
      var ifok = await _context.CmfUsers1.FirstOrDefaultAsync(x => x.Id == uid && x.Coin >= total);
      if (ifok == null)
      {
        rs.code = 1009;
        rs.msg = "余额不足";
        if (lan == "En") rs.msg = "Insufficient balance";
        if (lan == "Nam") rs.msg = "Số dư không đủ";
        return rs;
      }
      else
      {

        ifok.Coin -= total;
        ifok.Consumption += total;
        _context.CmfUsers1.Update(ifok);
        try
        {
          _context.CmfReds.Add(data);
        }
        catch (Exception ex)
        {
          System.Console.WriteLine(ex.Message);
          rs.msg = "发送失败，请重试";
          if (lan == "En") rs.msg = "Failed to send, please try again";
          if (lan == "Nam") rs.msg = "Gửi thất bại, vui lòng thử lại";
          rs.code = 1009;
          return rs;
        }
        var dataCoinRecord = new CmfUserCoinrecord()
        {
          Type = 0,
          Action = 8,
          Uid = uid,
          Touid = uid,
          Giftid = data.Id,
          Giftcount = 1,
          Totalcoin = data.Coin,
          Showid = data.Showid,
          Addtime = data.Addtime
        };
        _context.CmfUserCoinrecords.Add(dataCoinRecord);
        await _context.SaveChangesAsync();
        rs.info = data;
        return rs;
      }

    }

    public int[] redlist(ulong total, uint nums, int type)
    {
        int[] list = {};
      if (type == 1)
      {
          list = red_rand_list2(total, nums);
      }else{
          list = red_average(total,nums);
      }
      return list;
    }
    private int[] red_average(ulong total,uint nums){
        var coin = Math.Floor((decimal)(total/nums));
        int[] list = {};
        for(var i =0;i<nums;i++){
            list[i] = (int)coin;
        }
        return list;
    }
    private int[] red_rand_list2(ulong total, uint num)
    {
      var list = new int[num];
      if ((uint)num > total) num = (uint)total;
      for (var n = 0; n < num; n++)
      {
        list[n] = 1;
        total = total - 1;
      }
      while (total > 0)
      {
        for (var count = 0; count < list.Count(); count++)
        {
          var diamonds = (uint)Utils.rand(1, 19);
          if (total >= diamonds)
          {
            total -= diamonds;
          }
          else
          {
            if (total >= 1)
            {
              diamonds = 1;
              total -= diamonds;
            }
          }
          list[count] = (int)(list[count] * diamonds);
          count++;
          if (total == 0)
          {
            break;
          }

        }
      }
      return list;
    }

  }
}
