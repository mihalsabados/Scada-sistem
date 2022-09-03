using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Scada
{
    [ServiceContract(SessionMode =SessionMode.Required)]
    public interface IDatabaseManager
    {
        [OperationContract(IsInitiating = true, IsTerminating = false)]
        string Login(string username, string password);
        [OperationContract]
        bool Registration(string username, string password);
        [OperationContract(IsTerminating = true, IsInitiating =false)]
        bool Logout(string token);
        [OperationContract]
        bool AddDI(string tagId, string description, string driver, string address, double scanTime, bool scanOn);
        [OperationContract]
        bool AddDO(string tagId, string description, string address, double initValue);
        [OperationContract]
        bool AddAI(string tagId, string description, string driver, string address, double scanTime, bool scanOn, double lowLimit, double highLimit, string units);
        [OperationContract]
        bool AddAO(string tagId, string description, string address, double initValue, double lowLimit, double highLimit, string units);
        [OperationContract]
        List<string> getAllTagNames();
        [OperationContract]
        void RemoveTag(string tagId);
        [OperationContract]
        List<string> getInputTagNames();
        [OperationContract]
        List<string> getAITagNames();
        [OperationContract]
        KeyValuePair<double, double> getRangeOfOutputTag(string tagId);
        [OperationContract]
        void ScanOnOff(string tagId, bool scan);
        [OperationContract]
        Dictionary<string,double> GetOutputValues();
        [OperationContract]
        void ChangeOutputValue(string tagId, double newValue);
        [OperationContract]
        void addAlarm(string tagId, string type, int priority, double limit);

    }
}
