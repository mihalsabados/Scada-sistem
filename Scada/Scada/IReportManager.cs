using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Scada
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IReportManager" in both code and config file together.
    [ServiceContract]
    public interface IReportManager
    {
        [OperationContract]
        List<AlarmHistory> AlarmLogInTime(DateTime from, DateTime to);
        [OperationContract]
        List<AlarmHistory> AlarmsWithPriority(int priority);
        [OperationContract]
        List<TagValue> TagsValuesInTime(DateTime from, DateTime to);
        [OperationContract]
        List<TagValue> LastAITagValue();
        [OperationContract]
        List<TagValue> LastDITagValue();
        [OperationContract]
        List<TagValue> TagValues(string tagId);
        [OperationContract]
        List<string> AllTags();
    }
}
