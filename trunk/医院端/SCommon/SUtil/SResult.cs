using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SCommon.SUtil
{
    public class SResult
    {
        public bool success { get; set; }
        public string code { get; set; }
        public string message { get; set; }
        public object data { get; set; }
    }
}
