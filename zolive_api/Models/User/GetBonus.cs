namespace zolive_api.Models.User
{

    public class BonusList
    {
        public int day { get; set; }
        public int coin { get; set; }
    }
    
    public class InfoBonus
    {
        public string bonus_switch { get; set; }
        public int bonus_day { get; set; }
        public int count_day { get; set; }
        public IList<BonusList> bonus_list { get; set; }
        public long bonus_time { get; set; }
    }
    public class SignInfo
    {
        public int bonus_day { get; set; }
        public long bonus_time { get; set; }
        public int count_day { get; set; }
    }

}
