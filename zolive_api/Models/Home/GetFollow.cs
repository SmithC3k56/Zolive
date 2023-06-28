using zolive_db.Models;

namespace zolive_api.Models.Home
{
    public class GetFollow
    {
    }
    public class InfoGetFollow
    {
        public string title { get; set; }
        public string des { get; set; }
        public IList<GetHotModel> list { get; set; }
    }
    public class SearchModel {
        public uint level { get; set; }
        public uint level_anchor { get; set; }
        public sbyte isattention { get; set; }
        public string? avatar { get; set; }
    }

}
