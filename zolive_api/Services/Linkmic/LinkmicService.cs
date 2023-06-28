using Microsoft.EntityFrameworkCore;
using zolive_api.Services.Interface;
using zolive_db.Models;

namespace zolive_api.Services.Linkmic
{
    public class LinkmicService: ILinkmicService
    {
        public readonly newliveContext context;

        public LinkmicService(newliveContext context)
        {
            this.context = context;
        }

        public int setMic(ulong uid, int ismic)
        {
            var live = context.CmfLives.FirstOrDefault(x => x.Uid == uid);
            if (live != null)
            {
                live.Ismic = ismic;
                context.CmfLives.Update(live);
                context.SaveChanges();
                if (live.Ismic == 1)
                {
                    return 1;
                }
            }
            return 0;
        }
    }
}
