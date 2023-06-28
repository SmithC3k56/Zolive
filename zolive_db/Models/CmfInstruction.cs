using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfInstruction
    {
        public int Id { get; set; }
        /// <summary>
        /// 说明
        /// </summary>
        public string AddDesc { get; set; } = null!;
    }
}
