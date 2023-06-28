using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfPageSetting
    {
        public int Id { get; set; }
        public string Img { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Desc { get; set; } = null!;
        public int IsOpen { get; set; }
        public string Url { get; set; } = null!;
        public int UpdateTime { get; set; }
        public int Sort { get; set; }
        public int Type { get; set; }
    }
}
