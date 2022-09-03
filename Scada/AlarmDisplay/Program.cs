using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace AlarmDisplay
{
    class Callback : ServiceReference.IAlarmDisplayCallback
    {
        public void sendAlarmNotificatio(string tagId, string type, DateTime time, int priority)
        {
            for (int i = 0; i < priority; i++)
                Console.WriteLine(tagId+"\t\t|\t"+type+"\t|\t"+time);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Callback cb = new Callback();
            InstanceContext ic = new InstanceContext(cb);
            ServiceReference.AlarmDisplayClient client = new ServiceReference.AlarmDisplayClient(ic);
            Console.WriteLine("===== Alarm log =====");
            Console.WriteLine("Tag\t\t|\tType\t|\tTime");
            client.initAlarmDisplay();
            Console.ReadKey();
        }
    }
}
