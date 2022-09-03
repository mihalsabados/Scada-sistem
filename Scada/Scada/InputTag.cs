using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Scada
{
    public class InputTag:Tag
    {
        public string Driver { get; set; }
        public double ScanTime { get; set; }
        public bool ScanOn { get; set; }
    }
}