using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;

namespace Trending
{
    public class Callback : ServiceReference.ITrendingCallback
    {
        private Dictionary<string, double> tagValue;

        public Callback()
        {
            tagValue = new Dictionary<string, double>();
        }

        private void writeToConsole()
        {
            foreach (var key in tagValue.Keys)
                Console.WriteLine(key+"\t\t| " +tagValue[key]);
        }
        public void ClearConsole()
        {
            for (int i = 1; i <= tagValue.Keys.Count; i++)
            {
                Console.SetCursorPosition(0, i);
                int currentLineCursor = Console.CursorTop;
                Console.SetCursorPosition(0, Console.CursorTop);
                Console.Write(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(0, currentLineCursor);
            }
            
        }

        public void tagValueChanged(string tagId, double currentValue)
        {
            tagValue[tagId] = currentValue;
            ClearConsole();
            writeToConsole();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Callback cb = new Callback();
            InstanceContext ic = new InstanceContext(cb);
            ServiceReference.TrendingClient client = new ServiceReference.TrendingClient(ic);
            
            Console.WriteLine("Tag\t\t|\tValue");
            client.initTrending();

            Console.ReadKey();
        }

       
    }
}
