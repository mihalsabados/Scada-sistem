﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DatabaseManager.ServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference.IDatabaseManager", SessionMode=System.ServiceModel.SessionMode.Required)]
    public interface IDatabaseManager {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDatabaseManager/Login", ReplyAction="http://tempuri.org/IDatabaseManager/LoginResponse")]
        string Login(string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDatabaseManager/Login", ReplyAction="http://tempuri.org/IDatabaseManager/LoginResponse")]
        System.Threading.Tasks.Task<string> LoginAsync(string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDatabaseManager/Registration", ReplyAction="http://tempuri.org/IDatabaseManager/RegistrationResponse")]
        bool Registration(string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDatabaseManager/Registration", ReplyAction="http://tempuri.org/IDatabaseManager/RegistrationResponse")]
        System.Threading.Tasks.Task<bool> RegistrationAsync(string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(IsTerminating=true, IsInitiating=false, Action="http://tempuri.org/IDatabaseManager/Logout", ReplyAction="http://tempuri.org/IDatabaseManager/LogoutResponse")]
        bool Logout(string token);
        
        [System.ServiceModel.OperationContractAttribute(IsTerminating=true, IsInitiating=false, Action="http://tempuri.org/IDatabaseManager/Logout", ReplyAction="http://tempuri.org/IDatabaseManager/LogoutResponse")]
        System.Threading.Tasks.Task<bool> LogoutAsync(string token);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDatabaseManager/AddDI", ReplyAction="http://tempuri.org/IDatabaseManager/AddDIResponse")]
        bool AddDI(string tagId, string description, string driver, string address, double scanTime, bool scanOn);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDatabaseManager/AddDI", ReplyAction="http://tempuri.org/IDatabaseManager/AddDIResponse")]
        System.Threading.Tasks.Task<bool> AddDIAsync(string tagId, string description, string driver, string address, double scanTime, bool scanOn);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDatabaseManager/AddDO", ReplyAction="http://tempuri.org/IDatabaseManager/AddDOResponse")]
        bool AddDO(string tagId, string description, string address, double initValue);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDatabaseManager/AddDO", ReplyAction="http://tempuri.org/IDatabaseManager/AddDOResponse")]
        System.Threading.Tasks.Task<bool> AddDOAsync(string tagId, string description, string address, double initValue);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDatabaseManager/AddAI", ReplyAction="http://tempuri.org/IDatabaseManager/AddAIResponse")]
        bool AddAI(string tagId, string description, string driver, string address, double scanTime, bool scanOn, double lowLimit, double highLimit, string units);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDatabaseManager/AddAI", ReplyAction="http://tempuri.org/IDatabaseManager/AddAIResponse")]
        System.Threading.Tasks.Task<bool> AddAIAsync(string tagId, string description, string driver, string address, double scanTime, bool scanOn, double lowLimit, double highLimit, string units);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDatabaseManager/AddAO", ReplyAction="http://tempuri.org/IDatabaseManager/AddAOResponse")]
        bool AddAO(string tagId, string description, string address, double initValue, double lowLimit, double highLimit, string units);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDatabaseManager/AddAO", ReplyAction="http://tempuri.org/IDatabaseManager/AddAOResponse")]
        System.Threading.Tasks.Task<bool> AddAOAsync(string tagId, string description, string address, double initValue, double lowLimit, double highLimit, string units);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDatabaseManager/getAllTagNames", ReplyAction="http://tempuri.org/IDatabaseManager/getAllTagNamesResponse")]
        string[] getAllTagNames();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDatabaseManager/getAllTagNames", ReplyAction="http://tempuri.org/IDatabaseManager/getAllTagNamesResponse")]
        System.Threading.Tasks.Task<string[]> getAllTagNamesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDatabaseManager/RemoveTag", ReplyAction="http://tempuri.org/IDatabaseManager/RemoveTagResponse")]
        void RemoveTag(string tagId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDatabaseManager/RemoveTag", ReplyAction="http://tempuri.org/IDatabaseManager/RemoveTagResponse")]
        System.Threading.Tasks.Task RemoveTagAsync(string tagId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDatabaseManager/getInputTagNames", ReplyAction="http://tempuri.org/IDatabaseManager/getInputTagNamesResponse")]
        string[] getInputTagNames();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDatabaseManager/getInputTagNames", ReplyAction="http://tempuri.org/IDatabaseManager/getInputTagNamesResponse")]
        System.Threading.Tasks.Task<string[]> getInputTagNamesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDatabaseManager/getAITagNames", ReplyAction="http://tempuri.org/IDatabaseManager/getAITagNamesResponse")]
        string[] getAITagNames();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDatabaseManager/getAITagNames", ReplyAction="http://tempuri.org/IDatabaseManager/getAITagNamesResponse")]
        System.Threading.Tasks.Task<string[]> getAITagNamesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDatabaseManager/getRangeOfOutputTag", ReplyAction="http://tempuri.org/IDatabaseManager/getRangeOfOutputTagResponse")]
        System.Collections.Generic.KeyValuePair<double, double> getRangeOfOutputTag(string tagId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDatabaseManager/getRangeOfOutputTag", ReplyAction="http://tempuri.org/IDatabaseManager/getRangeOfOutputTagResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.KeyValuePair<double, double>> getRangeOfOutputTagAsync(string tagId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDatabaseManager/ScanOnOff", ReplyAction="http://tempuri.org/IDatabaseManager/ScanOnOffResponse")]
        void ScanOnOff(string tagId, bool scan);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDatabaseManager/ScanOnOff", ReplyAction="http://tempuri.org/IDatabaseManager/ScanOnOffResponse")]
        System.Threading.Tasks.Task ScanOnOffAsync(string tagId, bool scan);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDatabaseManager/GetOutputValues", ReplyAction="http://tempuri.org/IDatabaseManager/GetOutputValuesResponse")]
        System.Collections.Generic.Dictionary<string, double> GetOutputValues();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDatabaseManager/GetOutputValues", ReplyAction="http://tempuri.org/IDatabaseManager/GetOutputValuesResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.Dictionary<string, double>> GetOutputValuesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDatabaseManager/ChangeOutputValue", ReplyAction="http://tempuri.org/IDatabaseManager/ChangeOutputValueResponse")]
        void ChangeOutputValue(string tagId, double newValue);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDatabaseManager/ChangeOutputValue", ReplyAction="http://tempuri.org/IDatabaseManager/ChangeOutputValueResponse")]
        System.Threading.Tasks.Task ChangeOutputValueAsync(string tagId, double newValue);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDatabaseManager/addAlarm", ReplyAction="http://tempuri.org/IDatabaseManager/addAlarmResponse")]
        void addAlarm(string tagId, string type, int priority, double limit);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDatabaseManager/addAlarm", ReplyAction="http://tempuri.org/IDatabaseManager/addAlarmResponse")]
        System.Threading.Tasks.Task addAlarmAsync(string tagId, string type, int priority, double limit);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IDatabaseManagerChannel : DatabaseManager.ServiceReference.IDatabaseManager, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DatabaseManagerClient : System.ServiceModel.ClientBase<DatabaseManager.ServiceReference.IDatabaseManager>, DatabaseManager.ServiceReference.IDatabaseManager {
        
        public DatabaseManagerClient() {
        }
        
        public DatabaseManagerClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public DatabaseManagerClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DatabaseManagerClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DatabaseManagerClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string Login(string username, string password) {
            return base.Channel.Login(username, password);
        }
        
        public System.Threading.Tasks.Task<string> LoginAsync(string username, string password) {
            return base.Channel.LoginAsync(username, password);
        }
        
        public bool Registration(string username, string password) {
            return base.Channel.Registration(username, password);
        }
        
        public System.Threading.Tasks.Task<bool> RegistrationAsync(string username, string password) {
            return base.Channel.RegistrationAsync(username, password);
        }
        
        public bool Logout(string token) {
            return base.Channel.Logout(token);
        }
        
        public System.Threading.Tasks.Task<bool> LogoutAsync(string token) {
            return base.Channel.LogoutAsync(token);
        }
        
        public bool AddDI(string tagId, string description, string driver, string address, double scanTime, bool scanOn) {
            return base.Channel.AddDI(tagId, description, driver, address, scanTime, scanOn);
        }
        
        public System.Threading.Tasks.Task<bool> AddDIAsync(string tagId, string description, string driver, string address, double scanTime, bool scanOn) {
            return base.Channel.AddDIAsync(tagId, description, driver, address, scanTime, scanOn);
        }
        
        public bool AddDO(string tagId, string description, string address, double initValue) {
            return base.Channel.AddDO(tagId, description, address, initValue);
        }
        
        public System.Threading.Tasks.Task<bool> AddDOAsync(string tagId, string description, string address, double initValue) {
            return base.Channel.AddDOAsync(tagId, description, address, initValue);
        }
        
        public bool AddAI(string tagId, string description, string driver, string address, double scanTime, bool scanOn, double lowLimit, double highLimit, string units) {
            return base.Channel.AddAI(tagId, description, driver, address, scanTime, scanOn, lowLimit, highLimit, units);
        }
        
        public System.Threading.Tasks.Task<bool> AddAIAsync(string tagId, string description, string driver, string address, double scanTime, bool scanOn, double lowLimit, double highLimit, string units) {
            return base.Channel.AddAIAsync(tagId, description, driver, address, scanTime, scanOn, lowLimit, highLimit, units);
        }
        
        public bool AddAO(string tagId, string description, string address, double initValue, double lowLimit, double highLimit, string units) {
            return base.Channel.AddAO(tagId, description, address, initValue, lowLimit, highLimit, units);
        }
        
        public System.Threading.Tasks.Task<bool> AddAOAsync(string tagId, string description, string address, double initValue, double lowLimit, double highLimit, string units) {
            return base.Channel.AddAOAsync(tagId, description, address, initValue, lowLimit, highLimit, units);
        }
        
        public string[] getAllTagNames() {
            return base.Channel.getAllTagNames();
        }
        
        public System.Threading.Tasks.Task<string[]> getAllTagNamesAsync() {
            return base.Channel.getAllTagNamesAsync();
        }
        
        public void RemoveTag(string tagId) {
            base.Channel.RemoveTag(tagId);
        }
        
        public System.Threading.Tasks.Task RemoveTagAsync(string tagId) {
            return base.Channel.RemoveTagAsync(tagId);
        }
        
        public string[] getInputTagNames() {
            return base.Channel.getInputTagNames();
        }
        
        public System.Threading.Tasks.Task<string[]> getInputTagNamesAsync() {
            return base.Channel.getInputTagNamesAsync();
        }
        
        public string[] getAITagNames() {
            return base.Channel.getAITagNames();
        }
        
        public System.Threading.Tasks.Task<string[]> getAITagNamesAsync() {
            return base.Channel.getAITagNamesAsync();
        }
        
        public System.Collections.Generic.KeyValuePair<double, double> getRangeOfOutputTag(string tagId) {
            return base.Channel.getRangeOfOutputTag(tagId);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.KeyValuePair<double, double>> getRangeOfOutputTagAsync(string tagId) {
            return base.Channel.getRangeOfOutputTagAsync(tagId);
        }
        
        public void ScanOnOff(string tagId, bool scan) {
            base.Channel.ScanOnOff(tagId, scan);
        }
        
        public System.Threading.Tasks.Task ScanOnOffAsync(string tagId, bool scan) {
            return base.Channel.ScanOnOffAsync(tagId, scan);
        }
        
        public System.Collections.Generic.Dictionary<string, double> GetOutputValues() {
            return base.Channel.GetOutputValues();
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.Dictionary<string, double>> GetOutputValuesAsync() {
            return base.Channel.GetOutputValuesAsync();
        }
        
        public void ChangeOutputValue(string tagId, double newValue) {
            base.Channel.ChangeOutputValue(tagId, newValue);
        }
        
        public System.Threading.Tasks.Task ChangeOutputValueAsync(string tagId, double newValue) {
            return base.Channel.ChangeOutputValueAsync(tagId, newValue);
        }
        
        public void addAlarm(string tagId, string type, int priority, double limit) {
            base.Channel.addAlarm(tagId, type, priority, limit);
        }
        
        public System.Threading.Tasks.Task addAlarmAsync(string tagId, string type, int priority, double limit) {
            return base.Channel.addAlarmAsync(tagId, type, priority, limit);
        }
    }
}
