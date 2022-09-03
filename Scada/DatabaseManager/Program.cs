using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseManager
{
    class Program
    {
        static ServiceReference.DatabaseManagerClient client = new ServiceReference.DatabaseManagerClient();
        static void Main(string[] args)
        {
            string token = null;
            bool failedLogIn;
            do
            {
                failedLogIn = false;
                Console.WriteLine("=== LogIn ===");
                Console.WriteLine("Username: ");
                string username = Console.ReadLine();
                Console.WriteLine("Password: ");
                string password = Console.ReadLine();
                token = client.Login(username, password);
                if (token.Equals("Login failed"))
                {
                    failedLogIn = true;
                    Console.WriteLine("Wrong credentials!\nPlease try again.");
                }
            } while (failedLogIn);
            Console.WriteLine("Successful logIn.");

            bool loop;
            do
            {
                loop = true;
                Console.WriteLine("===== Menu =====");
                Console.WriteLine("1 - Register user");
                Console.WriteLine("2 - Add tag");
                Console.WriteLine("3 - Remove tag");
                Console.WriteLine("4 - Turn Scan on");
                Console.WriteLine("5 - Turn Scan off");
                Console.WriteLine("6 - Get output values");
                Console.WriteLine("7 - Change output value");
                Console.WriteLine("8 - Add alarm");
                Console.WriteLine("9 - Log out and exit");
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
                        RegisterUser();
                        break;
                    case 2:
                        AddTag();
                        break;
                    case 3:
                        RemoveTag();
                        break;
                    case 4:
                        TurnScanOnOff(true);
                        break;
                    case 5:
                        TurnScanOnOff(false);
                        break;
                    case 6:
                        GetOutputValues();
                        break;
                    case 7:
                        ChangeOutputValues();
                        break;
                    case 8:
                        AddAlarm();
                        break;
                    case 9:
                        client.Logout(token);
                        loop = false;
                        break;
                    default:
                        Console.WriteLine("Bad input!");
                        break;
                }
            } while (loop);
        }

        private static void AddAlarm()
        {
            var allAITagNames = client.getAITagNames();
            string id;
            bool badId;
            do
            {
                badId = false;
                Console.WriteLine("All Analog input tags: ");
                foreach (var tag in allAITagNames)
                    Console.WriteLine(tag);
                Console.WriteLine("Select tag to add alarm: ");
                id = Console.ReadLine();
                if (!allAITagNames.Contains(id))
                { 
                    badId = true; 
                    Console.WriteLine("Bad Id!"); 
                }
            } while (badId);
            string input;
            do
            {
                Console.WriteLine("Alarm type (l-low, h-high): ");
                input = Console.ReadLine();
                if (!input.Equals("l") && !input.Equals("h"))
                    Console.WriteLine("Bad input!");
            } while (!input.Equals("l") && !input.Equals("h"));
            int priority = 0;
            do
            {
                Console.WriteLine("Alarm priority (1,2,3): ");
                try
                {
                    priority = Int32.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Not a number");
                    continue;
                }
                if (priority != 1 && priority != 2 && priority != 3)
                    Console.WriteLine("Bad input!");
            } while (priority != 1 && priority != 2 && priority != 3);
            double limit = 0;
            
            do
            {
                Console.WriteLine("Limit: ");
                try
                {
                    limit = Double.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Not a number!");
                    continue;
                }
            } while (false);

            client.addAlarm(id, (input.Equals("l") ? "LOW" : "HIGH"), priority, limit);
            Console.WriteLine("Alarm successfully added to tag: "+ id);
        }

        private static void ChangeOutputValues()
        {
            var outputTagValues = client.GetOutputValues();
            bool badId;
            do
            {
                badId = false;
                GetOutputValues();
                Console.WriteLine("type tag which you want to change output value: ");
                string id = Console.ReadLine();
                if (outputTagValues.Keys.Contains(id))
                {
                    KeyValuePair<double, double> kv = client.getRangeOfOutputTag(id);
                    bool outOfRange;
                    double newValue = 0;
                    do
                    {
                        outOfRange = false;
                        Console.WriteLine("input new value in range["+kv.Key+", "+kv.Value+"]: ");
                        newValue = double.Parse(Console.ReadLine());
                        if (newValue < kv.Key || newValue > kv.Value)
                        {
                            Console.WriteLine("New value is out of range!");
                            outOfRange = true;
                        }
                    } while (outOfRange);

                    client.ChangeOutputValue(id, newValue);
                    Console.WriteLine("Value of tag " + id + " has been changed to " + newValue);
                }
                else
                {
                    badId = true;
                    Console.WriteLine("Tag with id: " + id + " doesn't exist!\n Please try again.");
                }
            } while (badId);
        }

        private static void GetOutputValues()
        {
            Console.WriteLine("-- All output tag values --");
            foreach (var tag in client.GetOutputValues())
                Console.WriteLine(tag.Key+" = "+tag.Value);
        }

        private static void TurnScanOnOff(bool scan)
        {
            Console.WriteLine("-- Turning scan On/Off --");
            var allInputTags = client.getInputTagNames();
            bool badId;
            do
            {
                badId = false;
                foreach (var tagId in allInputTags)
                    Console.WriteLine("\t" + tagId);

                Console.WriteLine("type tag to turn scan "+(scan?"On":"Off")+": ");
                string id = Console.ReadLine();
                if (allInputTags.Contains(id))
                {
                    client.ScanOnOff(id, scan);
                    Console.WriteLine("Tags " + id + " scan has been successfully turned "+ (scan?"On":"Off"));
                }
                else
                {
                    badId = true;
                    Console.WriteLine("Tag with id: " + id + " doesn't exist!\n Please try again.");
                }
            } while (badId);

        }

        private static void RemoveTag()
        {
            Console.WriteLine("-- All tags --");
            var allTagNames = client.getAllTagNames();
            bool badId;
            do
            {
                badId = false;
                foreach (var tagId in allTagNames)
                    Console.WriteLine("\t" + tagId);

                Console.WriteLine("type tag which will be deleted: ");
                string id = Console.ReadLine();
                if (allTagNames.Contains(id))
                {
                    client.RemoveTag(id);
                    Console.WriteLine("Tag "+id+" has been successfully removed.");
                }
                else
                {
                    badId = true;
                    Console.WriteLine("Tag with id: "+id+" doesn't exist!\n Please try again.");
                }
            } while (badId);
        }

        private static void addTagByType(string type)
        {
            var allTags = client.getAllTagNames();
            string tagId;
            do
            {
                Console.WriteLine("Tag name: ");
                tagId = Console.ReadLine();
                if (allTags.Contains(tagId))
                {
                    Console.WriteLine("Tag named: " + tagId + " already exists!\nPlease try again.");
                }
            } while (allTags.Contains(tagId));
            Console.WriteLine("Description: ");
            string description = Console.ReadLine();
            string driver = null;
            if (type.Equals("DI") || type.Equals("AI"))
            {
                Console.WriteLine("Driver: ");
                bool badDriver;
                do
                {
                    badDriver = false;
                    Console.WriteLine("1 - Simulation Driver");
                    Console.WriteLine("2 - Real-Time Driver");
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
                            driver = "SD";
                            break;
                        case 2:
                            driver = "RTD";
                            break;
                        default:
                            badDriver = true;
                            Console.WriteLine("Bad driver!\n Please try again.");
                            break;
                    }
                } while (badDriver);
            }
            Console.WriteLine("I/O address: ");
            string address = Console.ReadLine();
            double scanTime = 0;
            bool scanOn = false;
            if (type.Equals("DI") || type.Equals("AI"))
            {
                Console.WriteLine("Scan time: ");
                scanTime = Double.Parse(Console.ReadLine());

                bool badOption;
                
                do
                {
                    badOption = false;
                    Console.WriteLine("Scan: ");
                    Console.WriteLine("1 - On");
                    Console.WriteLine("2 - Off");
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
                            scanOn = true;
                            break;
                        case 2:
                            scanOn = false;
                            break;
                        default:
                            badOption = true;
                            Console.WriteLine("Bad option!\n Please try again.");
                            break;
                    }
                } while (badOption);
            }
            double initValue = 0;

            if (type.Equals("DO") || type.Equals("AO"))
            {
                bool outOfRange = false;
                do
                {
                    outOfRange = false;
                    Console.WriteLine("initial value: ");
                    initValue = Double.Parse(Console.ReadLine());
                    if (type.Equals("DO") && (initValue>1 || initValue<0))
                    {
                        outOfRange = true;
                        Console.WriteLine("init value: "+initValue+" is out of range[0,1]!");
                    }
                } while (outOfRange);
                
                if (type.Equals("DO"))
                    client.AddDO(tagId, description, address, initValue);
            }

            if (type.Equals("DI"))
                client.AddDI(tagId, description, driver, address, scanTime, scanOn);
            else if(type.Equals("AI") || type.Equals("AO"))
            {
                Console.WriteLine("low limit: ");
                double lowLimit = Double.Parse(Console.ReadLine());
                Console.WriteLine("high limit: ");
                double highLimit = Double.Parse(Console.ReadLine());
                Console.WriteLine("units: ");
                string units = Console.ReadLine();

                if (type.Equals("AI"))
                    client.AddAI(tagId, description, driver, address, scanTime, scanOn, lowLimit, highLimit, units);
                else
                    client.AddAO(tagId, description, address, initValue, lowLimit, highLimit, units);
            }
            Console.WriteLine("Tag named: "+tagId+" sucessfully added.");
        }

        private static void AddTag()
        {
            Console.WriteLine("-- Add Tag --");
            Console.WriteLine("Choose type");
            bool badOption;
            do
            {
                badOption = false;
                Console.WriteLine("1 - Digital Input");
                Console.WriteLine("2 - Digital Output");
                Console.WriteLine("3 - Analog Input");
                Console.WriteLine("4 - Analog Output");

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
                        addTagByType("DI");
                        break;
                    case 2:
                        addTagByType("DO");
                        break;
                    case 3:
                        addTagByType("AI");
                        break;
                    case 4:
                        addTagByType("AO");
                        break;
                    default:
                        badOption = true;
                        Console.WriteLine("Bad option!\n Please try again.");
                        break;
                }
            } while (badOption);
        }

        private static void RegisterUser()
        {
            Console.WriteLine("-- Register --");
            Console.WriteLine("username: ");
            string username = Console.ReadLine();
            Console.WriteLine("password: ");
            string password = Console.ReadLine();

            if(client.Registration(username, password))
            {
                Console.WriteLine("Successful registration.");
            }
            else
            {
                Console.WriteLine("Registration failed!");
            }
        }
    }

   

}
