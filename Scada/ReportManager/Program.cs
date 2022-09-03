using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportManager
{
    class Program
    {
        static ServiceReference.ReportManagerClient client = new ServiceReference.ReportManagerClient();
        static void Main(string[] args)
        {
            bool loop;
            do
            {
                loop = true;
                Console.WriteLine("===== Report Manager =====");
                Console.WriteLine("1 - All alarms between two dates");
                Console.WriteLine("2 - All alarms with priority");
                Console.WriteLine("3 - All tag values between two dates");
                Console.WriteLine("4 - Last AI tag values");
                Console.WriteLine("5 - Last DI tag values");
                Console.WriteLine("6 - All values of one tag");
                Console.WriteLine("7 - Exit");
                Console.WriteLine("Choose option: ");
                int option = 0;
                try
                {
                    option = Int32.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Bad input!");
                    continue;
                }

                switch (option)
                {
                    case 1:
                        AllAlarmsBetweenDates();
                        break;
                    case 2:
                        AllAlarmsWithPriority();
                        break;
                    case 3:
                        AllTagValuesBetweenDates();
                        break;
                    case 4:
                        LastAITagValues();
                        break;
                    case 5:
                        LastDITagValues();
                        break;
                    case 6:
                        AllValuesOfOneTag();
                        break;
                    case 7:
                        loop = false;
                        break;
                    default:
                        Console.WriteLine("Bad input!");
                        break;
                }
            } while (loop);

        }

        private static void AllValuesOfOneTag()
        {
            var allTags = client.AllTags();
            string inputTag;
            do
            {
                Console.WriteLine("All tags:");
                foreach (var tag in allTags)
                    Console.WriteLine(tag);
                Console.WriteLine("Select one tag: ");
                inputTag = Console.ReadLine();
                if (!allTags.Contains(inputTag))
                {
                    Console.WriteLine("No such tag!");
                    continue;
                }
            } while (false);
            try
            {
                var tv = client.TagValues(inputTag);
                Console.WriteLine("TagId\t\t| Value\t| Time");
                foreach (var item in tv)
                {
                    Console.WriteLine(item.TagId+"\t\t = "+item.currentValue+"\t"+item.Time);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Too much values!");
            }
        }

        private static void LastDITagValues()
        {
            var tv = client.LastDITagValue();
            Console.WriteLine("TagId\t\t| Value\t| Time");
            foreach (var item in tv)
            {
                Console.WriteLine(item.TagId + "\t\t = " + item.currentValue + "\t" + item.Time);
            }
        }

        private static void LastAITagValues()
        {
            var tv = client.LastAITagValue();
            Console.WriteLine("TagId\t\t| Value\t| Time");
            foreach (var item in tv)
            {
                Console.WriteLine(item.TagId + "\t\t = " + item.currentValue + "\t" + item.Time);
            }
        }

        private static void AllTagValuesBetweenDates()
        {
            DateTime fromDate = DateTime.Now;
            do
            {
                Console.WriteLine("Type from date:");
                try
                {
                    fromDate = DateTime.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Bad format!");
                    continue;
                }
            } while (false);
            DateTime toDate = DateTime.Now;
            do
            {
                Console.WriteLine("Type to date:");
                try
                {
                    toDate = DateTime.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Bad format!");
                    continue;
                }
            } while (false);
            Console.WriteLine(fromDate);
            Console.WriteLine(toDate);
            var tv = client.TagsValuesInTime(fromDate, toDate);
            Console.WriteLine("TagId\t\t| Value\t| Time");
            foreach (var item in tv)
            {
                Console.WriteLine(item.TagId + "\t\t = " + item.currentValue + "\t" + item.Time);
            }
        }

        private static void AllAlarmsWithPriority()
        {
            int priority = 1;
            bool badInput;
            do
            {
                badInput = false;
                Console.WriteLine("Type priority(1,2,3): ");
                try
                {
                    priority = Int32.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Not a number");
                    badInput = true;
                }
                if (priority != 1 && priority!=2 && priority!=3)
                {
                    Console.WriteLine("Bad priority!");
                    badInput = true;
                }
            } while (badInput);

            var alarms = client.AlarmsWithPriority(priority);
            foreach (var item in alarms)
            {
                Console.WriteLine(item.TagId + "\t\t" + item.Type + "\t" + item.Time+"\t"+item.Priority);
            }
        }

        private static void AllAlarmsBetweenDates()
        {
            DateTime fromDate = DateTime.Now;
            do
            {
                Console.WriteLine("Type from date:");
                try
                {
                    fromDate = DateTime.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Bad format!");
                    continue;
                }
            } while (false);
            DateTime toDate = DateTime.Now;
            do
            {
                Console.WriteLine("Type to date:");
                try
                {
                    toDate = DateTime.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Bad format!");
                    continue;
                }
            } while (false);

            var alarms = client.AlarmLogInTime(fromDate, toDate);
            foreach (var item in alarms)
            {
                Console.WriteLine(item.TagId + "\t\t" + item.Type + "\t" + item.Time + "\t" + item.Priority);
            }
        }
    }
}
