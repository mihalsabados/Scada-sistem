using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Scada
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "RealTimeUnit" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select RealTimeUnit.svc or RealTimeUnit.svc.cs at the Solution Explorer and start debugging.
    public class RealTimeUnit : IRealTimeUnit
    {
        //RealTimeUnit
        static Verification ver = new Verification();
        static int unitIdentification = 0;
        int unitId;
        static readonly object locker = new object();
        public string keyFilePath;
        static Dictionary<int, string> unitAddress = new Dictionary<int, string>();

        bool IsAddressFree(string address)
        {
            if (unitAddress.ContainsValue(address))
            {
                return false;
            }
            return true;
        }

        public int RealTimeUnitInit(string address)
        {
            //inicijalizacija 
            lock (locker)
            {
                if (IsAddressFree(address))
                {
                    unitId = unitIdentification;
                    unitAddress.Add(unitId, address);
                    unitIdentification++;
                    return unitId;
                }
                return -1;
            }
        }

        public void SetPublicKey(string keyPath)
        {
            lock (locker)
            {
                keyFilePath = keyPath;
            }

        }

        public void SetValue(string message, byte[] signature)
        {
            lock (locker)
            {
                ver.ImportPublicKey(keyFilePath);
                if (ver.VerifyMessage(message, signature))
                {
                    double value = Int32.Parse(message.Split('=')[1]);
                    RealTimeDriver.addressValue[unitAddress[unitId]] = value;
                }
            }
        }
    }
}
