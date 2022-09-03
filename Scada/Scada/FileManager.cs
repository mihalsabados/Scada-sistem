using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Scada
{
    public static class FileManager
    {
        private static string tagConfigpath = @"C:\Scada\scadaConfig.xml";
        private static string alarmConfigPath = @"C:\Scada\alarmConfig.xml";
        private static string alarmLogPath = @"C:\Scada\alarmLog.xml";


        public static Dictionary<string,Tag> readFromConfig()
        {
            if (!File.Exists(tagConfigpath))
            {
                return new Dictionary<string, Tag>();
            }
            XElement xmlData = XElement.Load(tagConfigpath);

            Dictionary<string, Tag> tags = new Dictionary<string, Tag>();

            var allDITags = xmlData.Descendants("DI");
            foreach (var item in allDITags)
            {
                string id = item.Attribute("id").Value;
                string description = item.Attribute("description").Value;
                string driver = item.Attribute("driver").Value;
                string address = item.Attribute("address").Value;
                double scanTime = Double.Parse(item.Attribute("scanTime").Value);
                bool scanOn = Boolean.Parse(item.Attribute("scanOn").Value);
                DI di = new DI(id, description, driver, address, scanTime, scanOn);
                tags.Add(id, di);
            }
            var allDOTags = xmlData.Descendants("DO");
            foreach (var item in allDOTags)
            {
                string id = item.Attribute("id").Value;
                string description = item.Attribute("description").Value;
                string address = item.Attribute("address").Value;
                double initValue = Double.Parse(item.Attribute("initValue").Value);
                DO dO = new DO(id, description, address, initValue);
                tags.Add(id, dO);
            }
            var allAITags = xmlData.Descendants("AI");
            foreach (var item in allAITags)
            {
                string id = item.Attribute("id").Value;
                string description = item.Attribute("description").Value;
                string driver = item.Attribute("driver").Value;
                string address = item.Attribute("address").Value;
                double scanTime = Double.Parse(item.Attribute("scanTime").Value);
                bool scanOn = Boolean.Parse(item.Attribute("scanOn").Value);
                double lowLimit = Double.Parse(item.Attribute("lowLimit").Value);
                double highLimit = Double.Parse(item.Attribute("highLimit").Value);
                string units = item.Attribute("units").Value;
                AI ai = new AI(id, description, driver, address, scanTime, null, scanOn, lowLimit, highLimit, units);
                tags.Add(id, ai);
            }
            var allAOTags = xmlData.Descendants("AO");
            foreach (var item in allAOTags)
            {
                string id = item.Attribute("id").Value;
                string description = item.Attribute("description").Value;
                string address = item.Attribute("address").Value;
                double initValue = Double.Parse(item.Attribute("initValue").Value);
                double lowLimit = Double.Parse(item.Attribute("lowLimit").Value);
                double highLimit = Double.Parse(item.Attribute("highLimit").Value);
                string units = item.Attribute("units").Value;
                AO ao = new AO(id, description, address, initValue, lowLimit, highLimit, units);
                tags.Add(id, ao);
            }
            return tags;
        }

        public static Tag getTagById(string Id)
        {
            Dictionary<string, Tag> tags = readFromConfig();
            return tags[Id];
        }

        public static void writeToConfig(Dictionary<string,Tag> allTags)
        {
            XDocument document = new XDocument();
            XElement tags = new XElement("Tags");
            foreach (var tag in allTags.Values)
            {
                XElement xElem = null;
                if (tag.GetType() == typeof(DI))
                {
                    DI di = (DI)tag;
                    xElem = new XElement("DI",
                        new XAttribute("id", di.Id),
                        new XAttribute("description", di.Description),
                        new XAttribute("driver", di.Driver),
                        new XAttribute("address",di.Address),
                        new XAttribute("scanTime",di.ScanTime),
                        new XAttribute("scanOn",di.ScanOn)
                        );
                    
                }
                else if (tag.GetType() == typeof(DO))
                {
                    DO dOut = (DO)tag;
                    xElem = new XElement("DO",
                        new XAttribute("id", dOut.Id),
                        new XAttribute("description", dOut.Description),
                        new XAttribute("address", dOut.Address),
                        new XAttribute("initValue", dOut.InitValue)
                        );
                }
                else if (tag.GetType() == typeof(AI))
                {
                    AI ai = (AI)tag;
                    xElem = new XElement("AI",
                        new XAttribute("id", ai.Id),
                        new XAttribute("description", ai.Description),
                        new XAttribute("driver", ai.Driver),
                        new XAttribute("address", ai.Address),
                        new XAttribute("scanTime", ai.ScanTime),
                        new XAttribute("scanOn", ai.ScanOn),
                        new XAttribute("lowLimit", ai.LowLimit),
                        new XAttribute("highLimit", ai.HighLimit),
                        new XAttribute("units", ai.Units)
                        );
                }
                else if (tag.GetType() == typeof(AO))
                {
                    AO ao = (AO)tag;
                    xElem = new XElement("AO",
                        new XAttribute("id", ao.Id),
                        new XAttribute("description", ao.Description),
                        new XAttribute("address", ao.Address),
                        new XAttribute("initValue", ao.InitValue),
                        new XAttribute("lowLimit", ao.LowLimit),
                        new XAttribute("highLimit", ao.HighLimit),
                        new XAttribute("units", ao.Units)
                        );
                }
                tags.Add(xElem);
            }
            document.Add(tags);
            System.IO.FileInfo file = new System.IO.FileInfo(tagConfigpath);
            file.Directory.Create();
            document.Save(tagConfigpath);
        }

        public static List<Alarm> getAlarmsForTag(string tag)
        {
            return readAlarms().Where(x => x.tagId == tag).ToList();
        }

        public static List<Alarm> readAlarms()
        {
            if (!File.Exists(alarmConfigPath))
            {
                return new List<Alarm>();
            }
            XElement xmlData = XElement.Load(alarmConfigPath);

            List<Alarm> alarms = new List<Alarm>();

            var allAlarms = xmlData.Descendants("Alarm");

            foreach (var alarm in allAlarms)
            {
                string tagId = alarm.Attribute("tagId").Value;
                Alarm.AlarmType type = (Alarm.AlarmType)Enum.Parse(typeof(Alarm.AlarmType), alarm.Attribute("type").Value);
                int priority = Int32.Parse(alarm.Attribute("priority").Value);
                double limit = Double.Parse(alarm.Attribute("limit").Value);
                Alarm a = new Alarm() { tagId = tagId, Limit = limit, Priority = priority, Type = type };
                alarms.Add(a);
            }

            return alarms;
        }

        public static void writeAlarmToConfig(List<Alarm> alarms)
        {
            XDocument document = new XDocument();
            XElement xAlarms = new XElement("Alarms");
            foreach (var alarm in alarms)
            {
                XElement xElem = new XElement("Alarm",
                    new XAttribute("tagId", alarm.tagId),
                    new XAttribute("type", alarm.Type.ToString()),
                    new XAttribute("priority", alarm.Priority),
                    new XAttribute("limit", alarm.Limit)
                    );
                xAlarms.Add(xElem);
            }
            document.Add(xAlarms);
            FileInfo file = new FileInfo(alarmConfigPath);
            file.Directory.Create();
            document.Save(alarmConfigPath);
        }

        public static void writeAlarmHistoryLog(List<AlarmHistory> alarms)
        {
            XDocument document = new XDocument();
            XElement xAlarmLogs = new XElement("AlarmLogs");
            foreach (var alarm in alarms)
            {
                XElement xElem = new XElement("AlarmLog",
                    new XAttribute("tagId", alarm.TagId),
                    new XAttribute("type", alarm.Type.ToString()),
                    new XAttribute("priority", alarm.Priority),
                    new XAttribute("limit", alarm.Limit),
                    new XAttribute("time", alarm.Time)
                    );
                xAlarmLogs.Add(xElem);
            }
            document.Add(xAlarmLogs);
            FileInfo file = new FileInfo(alarmLogPath);
            file.Directory.Create();
            document.Save(alarmLogPath);

        }
    }
}