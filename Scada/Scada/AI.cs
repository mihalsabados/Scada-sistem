using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Scada
{
    public class AI:InputTag
    {

        public List<Alarm> Alarms { get; set; }

        public double LowLimit { get; set; }

        public double HighLimit { get; set; }

        public string Units { get; set; }

        public AI(string id, string description, string driver, string address, double scanTime, List<Alarm> alarms, bool scanOn, double lowLimit, double highLimit, string units)
        {
            Id = id;
            Description = description;
            Driver = driver;
            Address = address;
            ScanTime = scanTime;
            Alarms = alarms;
            ScanOn = scanOn;
            LowLimit = lowLimit;
            HighLimit = highLimit;
            Units = units;
        }
    }
}