using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Scada
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AlarmDisplay" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select AlarmDisplay.svc or AlarmDisplay.svc.cs at the Solution Explorer and start debugging.
    public class AlarmDisplay : IAlarmDisplay
    {
        private static readonly object locker = new object();
        public void initAlarmDisplay()
        {
            lock (locker)
            {
                TagProccessing.sendAlarmNotification += OperationContext.Current.GetCallbackChannel<IAlarmCallback>().sendAlarmNotificatio;
            }
        }
    }
}
