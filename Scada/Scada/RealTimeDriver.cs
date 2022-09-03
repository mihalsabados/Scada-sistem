using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace Scada
{
    [ServiceContract]
    public static class RealTimeDriver
    {
        public static Dictionary<string, double> addressValue = new Dictionary<string, double>();

        public static double ReturnValue(string address)
        {
            if (addressValue.ContainsKey(address))
                return addressValue[address];
            return 0;
        }
    }
}