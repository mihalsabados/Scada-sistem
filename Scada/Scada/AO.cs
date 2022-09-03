using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Scada
{
    public class AO:OutputTag
    {
        public double LowLimit { get; set; }

        public double HighLimit { get; set; }

        public string Units { get; set; }

        public AO(string id, string description, string address, double initValue, double lowLimit, double highLimit, string units)
        {
            Id = id;
            Description = description;
            Address = address;
            InitValue = initValue;
            LowLimit = lowLimit;
            HighLimit = highLimit;
            Units = units;
        }
    }
}