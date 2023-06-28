using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfUsersVideoStep
    {
        public int Id { get; set; }
        public int? Uid { get; set; }
        public int? Videoid { get; set; }
        public int? Addtime { get; set; }
    }
}
