﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ReportManager.ServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="AlarmHistory", Namespace="http://schemas.datacontract.org/2004/07/Scada")]
    [System.SerializableAttribute()]
    public partial class AlarmHistory : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double LimitField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int PriorityField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TagIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime TimeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TypeField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double Limit {
            get {
                return this.LimitField;
            }
            set {
                if ((this.LimitField.Equals(value) != true)) {
                    this.LimitField = value;
                    this.RaisePropertyChanged("Limit");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Priority {
            get {
                return this.PriorityField;
            }
            set {
                if ((this.PriorityField.Equals(value) != true)) {
                    this.PriorityField = value;
                    this.RaisePropertyChanged("Priority");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string TagId {
            get {
                return this.TagIdField;
            }
            set {
                if ((object.ReferenceEquals(this.TagIdField, value) != true)) {
                    this.TagIdField = value;
                    this.RaisePropertyChanged("TagId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime Time {
            get {
                return this.TimeField;
            }
            set {
                if ((this.TimeField.Equals(value) != true)) {
                    this.TimeField = value;
                    this.RaisePropertyChanged("Time");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Type {
            get {
                return this.TypeField;
            }
            set {
                if ((object.ReferenceEquals(this.TypeField, value) != true)) {
                    this.TypeField = value;
                    this.RaisePropertyChanged("Type");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="TagValue", Namespace="http://schemas.datacontract.org/2004/07/Scada")]
    [System.SerializableAttribute()]
    public partial class TagValue : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TagIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime TimeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private ReportManager.ServiceReference.TagValue.TagType TypeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double currentValueField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string TagId {
            get {
                return this.TagIdField;
            }
            set {
                if ((object.ReferenceEquals(this.TagIdField, value) != true)) {
                    this.TagIdField = value;
                    this.RaisePropertyChanged("TagId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime Time {
            get {
                return this.TimeField;
            }
            set {
                if ((this.TimeField.Equals(value) != true)) {
                    this.TimeField = value;
                    this.RaisePropertyChanged("Time");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ReportManager.ServiceReference.TagValue.TagType Type {
            get {
                return this.TypeField;
            }
            set {
                if ((this.TypeField.Equals(value) != true)) {
                    this.TypeField = value;
                    this.RaisePropertyChanged("Type");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double currentValue {
            get {
                return this.currentValueField;
            }
            set {
                if ((this.currentValueField.Equals(value) != true)) {
                    this.currentValueField = value;
                    this.RaisePropertyChanged("currentValue");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
        [System.Runtime.Serialization.DataContractAttribute(Name="TagValue.TagType", Namespace="http://schemas.datacontract.org/2004/07/Scada")]
        public enum TagType : int {
            
            [System.Runtime.Serialization.EnumMemberAttribute()]
            INPUT = 0,
            
            [System.Runtime.Serialization.EnumMemberAttribute()]
            OUTPUT = 1,
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference.IReportManager")]
    public interface IReportManager {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReportManager/AlarmLogInTime", ReplyAction="http://tempuri.org/IReportManager/AlarmLogInTimeResponse")]
        ReportManager.ServiceReference.AlarmHistory[] AlarmLogInTime(System.DateTime from, System.DateTime to);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReportManager/AlarmLogInTime", ReplyAction="http://tempuri.org/IReportManager/AlarmLogInTimeResponse")]
        System.Threading.Tasks.Task<ReportManager.ServiceReference.AlarmHistory[]> AlarmLogInTimeAsync(System.DateTime from, System.DateTime to);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReportManager/AlarmsWithPriority", ReplyAction="http://tempuri.org/IReportManager/AlarmsWithPriorityResponse")]
        ReportManager.ServiceReference.AlarmHistory[] AlarmsWithPriority(int priority);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReportManager/AlarmsWithPriority", ReplyAction="http://tempuri.org/IReportManager/AlarmsWithPriorityResponse")]
        System.Threading.Tasks.Task<ReportManager.ServiceReference.AlarmHistory[]> AlarmsWithPriorityAsync(int priority);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReportManager/TagsValuesInTime", ReplyAction="http://tempuri.org/IReportManager/TagsValuesInTimeResponse")]
        ReportManager.ServiceReference.TagValue[] TagsValuesInTime(System.DateTime from, System.DateTime to);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReportManager/TagsValuesInTime", ReplyAction="http://tempuri.org/IReportManager/TagsValuesInTimeResponse")]
        System.Threading.Tasks.Task<ReportManager.ServiceReference.TagValue[]> TagsValuesInTimeAsync(System.DateTime from, System.DateTime to);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReportManager/LastAITagValue", ReplyAction="http://tempuri.org/IReportManager/LastAITagValueResponse")]
        ReportManager.ServiceReference.TagValue[] LastAITagValue();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReportManager/LastAITagValue", ReplyAction="http://tempuri.org/IReportManager/LastAITagValueResponse")]
        System.Threading.Tasks.Task<ReportManager.ServiceReference.TagValue[]> LastAITagValueAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReportManager/LastDITagValue", ReplyAction="http://tempuri.org/IReportManager/LastDITagValueResponse")]
        ReportManager.ServiceReference.TagValue[] LastDITagValue();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReportManager/LastDITagValue", ReplyAction="http://tempuri.org/IReportManager/LastDITagValueResponse")]
        System.Threading.Tasks.Task<ReportManager.ServiceReference.TagValue[]> LastDITagValueAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReportManager/TagValues", ReplyAction="http://tempuri.org/IReportManager/TagValuesResponse")]
        ReportManager.ServiceReference.TagValue[] TagValues(string tagId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReportManager/TagValues", ReplyAction="http://tempuri.org/IReportManager/TagValuesResponse")]
        System.Threading.Tasks.Task<ReportManager.ServiceReference.TagValue[]> TagValuesAsync(string tagId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReportManager/AllTags", ReplyAction="http://tempuri.org/IReportManager/AllTagsResponse")]
        string[] AllTags();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReportManager/AllTags", ReplyAction="http://tempuri.org/IReportManager/AllTagsResponse")]
        System.Threading.Tasks.Task<string[]> AllTagsAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IReportManagerChannel : ReportManager.ServiceReference.IReportManager, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ReportManagerClient : System.ServiceModel.ClientBase<ReportManager.ServiceReference.IReportManager>, ReportManager.ServiceReference.IReportManager {
        
        public ReportManagerClient() {
        }
        
        public ReportManagerClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ReportManagerClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ReportManagerClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ReportManagerClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public ReportManager.ServiceReference.AlarmHistory[] AlarmLogInTime(System.DateTime from, System.DateTime to) {
            return base.Channel.AlarmLogInTime(from, to);
        }
        
        public System.Threading.Tasks.Task<ReportManager.ServiceReference.AlarmHistory[]> AlarmLogInTimeAsync(System.DateTime from, System.DateTime to) {
            return base.Channel.AlarmLogInTimeAsync(from, to);
        }
        
        public ReportManager.ServiceReference.AlarmHistory[] AlarmsWithPriority(int priority) {
            return base.Channel.AlarmsWithPriority(priority);
        }
        
        public System.Threading.Tasks.Task<ReportManager.ServiceReference.AlarmHistory[]> AlarmsWithPriorityAsync(int priority) {
            return base.Channel.AlarmsWithPriorityAsync(priority);
        }
        
        public ReportManager.ServiceReference.TagValue[] TagsValuesInTime(System.DateTime from, System.DateTime to) {
            return base.Channel.TagsValuesInTime(from, to);
        }
        
        public System.Threading.Tasks.Task<ReportManager.ServiceReference.TagValue[]> TagsValuesInTimeAsync(System.DateTime from, System.DateTime to) {
            return base.Channel.TagsValuesInTimeAsync(from, to);
        }
        
        public ReportManager.ServiceReference.TagValue[] LastAITagValue() {
            return base.Channel.LastAITagValue();
        }
        
        public System.Threading.Tasks.Task<ReportManager.ServiceReference.TagValue[]> LastAITagValueAsync() {
            return base.Channel.LastAITagValueAsync();
        }
        
        public ReportManager.ServiceReference.TagValue[] LastDITagValue() {
            return base.Channel.LastDITagValue();
        }
        
        public System.Threading.Tasks.Task<ReportManager.ServiceReference.TagValue[]> LastDITagValueAsync() {
            return base.Channel.LastDITagValueAsync();
        }
        
        public ReportManager.ServiceReference.TagValue[] TagValues(string tagId) {
            return base.Channel.TagValues(tagId);
        }
        
        public System.Threading.Tasks.Task<ReportManager.ServiceReference.TagValue[]> TagValuesAsync(string tagId) {
            return base.Channel.TagValuesAsync(tagId);
        }
        
        public string[] AllTags() {
            return base.Channel.AllTags();
        }
        
        public System.Threading.Tasks.Task<string[]> AllTagsAsync() {
            return base.Channel.AllTagsAsync();
        }
    }
}