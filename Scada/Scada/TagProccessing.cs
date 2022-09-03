using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace Scada
{
    public static class TagProccessing
    {
        private static readonly object locker = new object();
        public delegate void SendNotification(string tagId, double currentValue);
        public delegate void SendAlarmNotification(string tagId, string type, DateTime time, int priority);
        public static event SendAlarmNotification sendAlarmNotification;
        public static event SendNotification sendChangedValues;
        public static List<Thread> threads = new List<Thread>();
        public static bool started = false;

        public static Dictionary<string,double> getAllTagsLastValue()
        {
            lock (locker)
            {
                Dictionary<string, double> tagValues = new Dictionary<string, double>();
                using (var db = new TagValueContext())
                {
                    if (db.TagValues.Count() == 0)
                    {
                        return new Dictionary<string, double>();
                    }
                    var query = (from tagVal in db.TagValues
                                 where tagVal.Type == TagValue.TagType.INPUT
                                 select tagVal.TagId).Distinct();

                    List<string> allTags = query.ToList();

                    foreach (var tag in allTags)
                    {
                        TagValue tagV = (from tagVal in db.TagValues
                                         where tag == tagVal.TagId
                                         orderby tagVal.Time descending
                                         select tagVal).First();
                        tagValues.Add(tag, tagV.currentValue);
                    }
                }
                return tagValues;
            }
        }

        public static void OnDbChanged()
        {
            foreach (var thread in threads)
                thread.Abort();
            startSimulation();
        }

        public static void startSimulation()
        {
            lock (locker)
            {
                using (var db = new TagValueContext())
                {
                    if (db.TagValues == null || db.TagValues.Count() == 0)
                        return;
                        

                    started = true;
                    var query = (from tagVal in db.TagValues
                                    where tagVal.Type == TagValue.TagType.INPUT
                                    select tagVal.TagId).Distinct();


                    List<string> allInputTags = query.ToList();

                    foreach (var tag in allInputTags)
                    {
                        Thread t = new Thread(readValue);
                        threads.Add(t);
                        t.Start(tag);
                    }
                }
            }
        }

        private static void readValue(object tagId)
        {
            string id = tagId.ToString();
            InputTag tag;
            lock (locker)
            {
                tag = (InputTag)FileManager.getTagById(id);
            }
            while (true)
            {
                if (tag.ScanOn)
                {
                    double newValue = (tag.Driver.Equals("SD")) ? SimulationDriver.SimulationDriver.ReturnValue(tag.Address) : RealTimeDriver.ReturnValue(tag.Address);
                    if (tag.GetType() == typeof(DI))
                    {
                        newValue = (newValue >= 50) ? 1 : 0;
                    }
                    else if (tag.GetType() == typeof(AI))
                    {
                        AI ai = (AI)tag;
                        if (newValue > ai.HighLimit)
                            newValue = ai.HighLimit;
                        else if (newValue < ai.LowLimit)
                            newValue = ai.LowLimit;
                    }
                    TagValue tv = new TagValue() { TagId = tag.Id, Type = TagValue.TagType.INPUT, currentValue = newValue, Time = DateTime.Now };
                    if (typeof(AI) == tag.GetType())
                    {
                        foreach (var alarm in FileManager.getAlarmsForTag(tag.Id))
                        {
                            if ((alarm.Type == Alarm.AlarmType.HIGH && newValue>alarm.Limit)
                                    ||(alarm.Type == Alarm.AlarmType.LOW && newValue < alarm.Limit))
                            {
                                lock (locker)
                                {
                                    using (var db = new AlarmHistoryContext())
                                    {
                                        db.alarmHistories.Add(new AlarmHistory() { Limit = alarm.Limit, Priority = alarm.Priority, TagId = alarm.tagId, Time = DateTime.Now, Type = alarm.Type.ToString() });
                                        db.SaveChanges();
                                        FileManager.writeAlarmHistoryLog(db.alarmHistories.ToList());
                                    }
                                    if (sendAlarmNotification != null)
                                        sendAlarmNotification(tag.Id, alarm.Type.ToString(), DateTime.Now, alarm.Priority);
                                }
                            }
                        }
                    }
                    
                    
                    lock (locker)
                    {
                        using (var db = new TagValueContext())
                        {
                            db.TagValues.Add(tv);
                            db.SaveChanges();
                        }
                        if (sendChangedValues != null)
                            sendChangedValues(tag.Id, newValue);
                    }
                    Thread.Sleep((int)(tag.ScanTime * 1000));
                }
            }
        }

    }
}