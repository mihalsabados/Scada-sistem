using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Scada
{
    public class DI:InputTag
    {
        public DI(string id, string description, string driver, string address, double scanTime, bool scanOn)
        {
            Id = id;
            Description = description;
            Driver = driver;
            Address = address;
            ScanTime = scanTime;
            ScanOn = scanOn;
        }


    }
}