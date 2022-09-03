using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Scada
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "DbManager" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select DbManager.svc or DbManager.svc.cs at the Solution Explorer and start debugging.
    public class DbManager : IDatabaseManager
    {
        public static Dictionary<string, Tag> tags = new Dictionary<string, Tag>();
        public static List<Alarm> alarms = new List<Alarm>();
        static readonly object locker = new object();
        public string Login(string username, string password)
        {
            using (var db = new UsersContext())
            {
                foreach (var user in db.Users)
                {
                    if (username == user.Username && Validation.ValidateEncryptedData(password, user.EncryptedPassword))
                    {
                        string token = Validation.GenerateToken(username);
                        Validation.authenticatedUsers.Add(token, user);
                        //if (tags.Keys.Count == 0)
                        return token;
                    }
                }
            }
            return "Login failed";
        }



        public bool Registration(string username, string password)
        {
            string encryptedPassword = Validation.EncryptData(password);
            User user = new User(username, encryptedPassword);
            using (var db = new UsersContext())
            {
                try
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    return false;
                }
            }
            return true;
        }

        public bool Logout(string token)
        {
            return Validation.authenticatedUsers.Remove(token);
        }

        private void addTagToDb(Tag tag)
        {
            lock (locker)
            {
                using (var db = new TagValueContext())
                {
                    double currentValue = 0;
                    TagValue.TagType type = TagValue.TagType.INPUT;
                    if (typeof(OutputTag).IsAssignableFrom(tag.GetType()))
                    {
                        OutputTag ot = (OutputTag)tag;
                        currentValue = ot.InitValue;
                        type = TagValue.TagType.OUTPUT;
                    }
                    db.TagValues.Add(new TagValue() { TagId = tag.Id, currentValue = currentValue, Time = DateTime.Now, Type = type });
                    db.SaveChanges();
                }
                TagProccessing.OnDbChanged();
            }
        }

        private void removeTagFromDb(string tagId)
        {
            lock (locker)
            {
                using (var db = new TagValueContext())
                {
                    foreach (var tagVal in db.TagValues)
                        if (tagVal.TagId == tagId)
                            db.TagValues.Remove(tagVal);
                    db.SaveChanges();
                }
                TagProccessing.OnDbChanged();
            }

        }

        public bool AddDI(string tagId, string description, string driver, string address, double scanTime, bool scanOn)
        {
            lock (locker)
            {
                DI di = new DI(tagId, description, driver, address, scanTime, scanOn);
                if (tags.ContainsKey(tagId))
                    return false;
                tags.Add(tagId, di);
                FileManager.writeToConfig(tags);
                addTagToDb(di);
                return true;
            }

        }

        public bool AddDO(string tagId, string description, string address, double initValue)
        {
            lock (locker)
            {
                DO dOp = new DO(tagId, description, address, initValue);
                if (tags.ContainsKey(tagId))
                    return false;
                tags.Add(tagId, dOp);
                FileManager.writeToConfig(tags);
                addTagToDb(dOp);
                return true;
            }
        }

        public bool AddAI(string tagId, string description, string driver, string address, double scanTime, bool scanOn, double lowLimit, double highLimit, string units)
        {
            lock (locker)
            {
                AI ai = new AI(tagId, description, driver, address, scanTime, null, scanOn, lowLimit, highLimit, units);
                if (tags.ContainsKey(tagId))
                    return false;
                tags.Add(tagId, ai);
                FileManager.writeToConfig(tags);
                addTagToDb(ai);
                return true;
            }
        }

        public bool AddAO(string tagId, string description, string address, double initValue, double lowLimit, double highLimit, string units)
        {
            lock (locker)
            {
                AO ao = new AO(tagId, description, address, initValue, lowLimit, highLimit, units);
                if (tags.ContainsKey(tagId))
                    return false;
                tags.Add(tagId, ao);
                FileManager.writeToConfig(tags);
                addTagToDb(ao);
                return true;
            }
        }

        public List<string> getAllTagNames()
        {
            lock (locker)
            {
                return tags.Keys.ToList();
            }
        }

        public void RemoveTag(string tagId)
        {
            lock (locker)
            {
                if (tags.ContainsKey(tagId))
                {
                    tags.Remove(tagId);
                    FileManager.writeToConfig(tags);
                    removeTagFromDb(tagId);
                }
            }
        }

        public List<string> getInputTagNames()
        {
            lock (locker)
            {
                return tags.Keys.Where(x => typeof(InputTag).IsAssignableFrom(tags[x].GetType())).ToList();
            }
        }

        public List<string> getAITagNames()
        {
            lock (locker)
            {
                return tags.Keys.Where(x => typeof(AI) == tags[x].GetType()).ToList();
            }

        }

        public void ScanOnOff(string tagId, bool scan)
        {
            lock (locker)
            {
                if (tags.ContainsKey(tagId))
                {
                    var type = tags[tagId].GetType();
                    InputTag input = (InputTag)tags[tagId];
                    input.ScanOn = scan;
                    FileManager.writeToConfig(tags);
                    TagProccessing.OnDbChanged();
                }
            }
        }

        public KeyValuePair<double, double> getRangeOfOutputTag(string tagId)
        {
            lock (locker)
            {
                KeyValuePair<double, double> kv;
                if (tags[tagId].GetType() == typeof(DO))
                    kv = new KeyValuePair<double, double>(0, 1);
                else
                {
                    AO ao = (AO)tags[tagId];
                    kv = new KeyValuePair<double, double>(ao.LowLimit, ao.HighLimit);
                }
                return kv;
            }

        }

        public Dictionary<string, double> GetOutputValues()
        {
            lock (locker)
            {
                var tagValues = TagProccessing.getAllTagsLastValue();
                if (tagValues.Count == 0)
                {
                    return tagValues;
                }
                var outputValues = TagProccessing.getAllTagsLastValue().Where(key => !getInputTagNames().Contains(key.Key));
                return outputValues.ToDictionary(x => x.Key, x => x.Value);
            }
        }

        public void ChangeOutputValue(string tagId, double newValue)
        {
            lock (locker)
            {
                if (tags.ContainsKey(tagId))
                {
                    using (var db = new TagValueContext())
                    {
                        db.TagValues.Add(new TagValue() { TagId = tagId, currentValue = newValue, Type = TagValue.TagType.OUTPUT, Time = DateTime.Now });
                        db.SaveChanges();
                    }
                    TagProccessing.OnDbChanged();
                }
            }
        }

        public void addAlarm(string tagId, string type, int priority, double limit)
        {
            lock (locker)
            {
                AI ai =(AI)tags[tagId];
                if (ai.Alarms == null)
                    ai.Alarms = new List<Alarm>();
                Alarm alarm = new Alarm() { Type = (Alarm.AlarmType)Enum.Parse(typeof(Alarm.AlarmType),type), Limit = limit, Priority = priority, tagId=tagId };
                ai.Alarms.Add(alarm);
                alarms.Add(alarm);
                FileManager.writeAlarmToConfig(alarms);
            }
        }
    }
}
