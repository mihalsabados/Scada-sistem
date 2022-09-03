using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Scada
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IRealTimeUnit" in both code and config file together.
    [ServiceContract(SessionMode = SessionMode.Required)]
    interface IRealTimeUnit
    {
        [OperationContract]
        int RealTimeUnitInit(string address);

        [OperationContract]
        void SetPublicKey(string keyPath);

        [OperationContract]
        void SetValue(string message, byte[] signature);

    }
}
