using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Scada
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ReportManager" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ReportManager.svc or ReportManager.svc.cs at the Solution Explorer and start debugging.
    public class ReportManager : IReportManager
    {
        private readonly object locker = new object();
        public List<AlarmHistory> AlarmLogInTime(DateTime fromDate, DateTime toDate)
        {
            lock (locker)
            {
                using (var db = new AlarmHistoryContext())
                {
                    var query = from alarm in db.alarmHistories
                                where DateTime.Compare(alarm.Time, fromDate) >= 0 && DateTime.Compare(alarm.Time, toDate) <= 0
                                orderby alarm.Priority,alarm.Time descending
                                select alarm;

                    return query.ToList();
                }
            }
        }

        public List<AlarmHistory> AlarmsWithPriority(int priority)
        {
            lock (locker)
            {
                using (var db = new AlarmHistoryContext())
                {
                    var query = from alarm in db.alarmHistories
                                where alarm.Priority == priority
                                orderby alarm.Time
                                select alarm;

                    return query.ToList();
                }
            }
        }

        public List<string> AllTags()
        {
            lock (locker)
            {
                return FileManager.readFromConfig().Values.Select(x => x.Id).ToList();
            }
        }

        public List<TagValue> LastAITagValue()
        {
            lock (locker)
            {
                using (var db = new TagValueContext())
                {
                    List<TagValue> tagValues = new List<TagValue>();

                    var tags = FileManager.readFromConfig();
                    List<string> AITags = tags.Values.Where(x => x.GetType() == typeof(AI)).Select(x => x.Id).ToList();

                    foreach (var tag in AITags)
                    {
                        TagValue tagV = (from tagVal in db.TagValues
                                         where tag == tagVal.TagId
                                         orderby tagVal.Time descending
                                         select tagVal).First();
                        tagValues.Add(tagV);
                    }
                    return tagValues.OrderBy(x=>x.Time).ToList();
                }

            }
        }

        public List<TagValue> LastDITagValue()
        {
            lock (locker)
            {
                using (var db = new TagValueContext())
                {
                    List<TagValue> tagValues = new List<TagValue>();

                    var tags = FileManager.readFromConfig();
                    List<string> DITags = tags.Values.Where(x => x.GetType() == typeof(DI)).Select(x => x.Id).ToList();

                    foreach (var tag in DITags)
                    {
                        TagValue tagV = (from tagVal in db.TagValues
                                         where tag == tagVal.TagId
                                         orderby tagVal.Time descending
                                         select tagVal).First();
                        tagValues.Add(tagV);
                    }
                    return tagValues.OrderBy(x => x.Time).ToList();
                }
            }
        }

        public List<TagValue> TagsValuesInTime(DateTime fromDate, DateTime toDate)
        {
            lock (locker)
            {
                using (var db = new TagValueContext())
                {
                    var tagValues = from tagVal in db.TagValues
                                    where DateTime.Compare(tagVal.Time, fromDate) >= 0 && DateTime.Compare(tagVal.Time, toDate) <= 0
                                    orderby tagVal.Time descending
                                    select tagVal;
                    return tagValues.ToList();
                }
            }
        }

        public List<TagValue> TagValues(string tagId)
        {
            lock (locker)
            {
                using (var db = new TagValueContext())
                {

                    var tagValues = from tagVal in db.TagValues
                                        where tagVal.TagId.Equals(tagId)
                                        orderby tagVal.currentValue
                                        select tagVal;
                    return tagValues.ToList();

                }

            }
        }
    }
}
