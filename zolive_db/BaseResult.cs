using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zolive_model.Models
{
    public class ThumbImgs
    {
        public string thumb { get; set; }
        public string href { get; set; }
    }

    public class Guildes
    {
        public string @switch { get; set; }
        public string type { get; set; }
        public string time { get; set; }
        public List<ThumbImgs> list { get; set; }
    }


    public class Debug
    {
        public List<object> stack { get; set; }
        public List<object> sqls { get; set; }
        public string version { get; set; } 
    }

    public class BaseResult
    {
        public int ret { get; set; }
        public dynamic data { get; set; }
        public string msg { get; set; }
        public Debug debug { get; set; }
    }

}
