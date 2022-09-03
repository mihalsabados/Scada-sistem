using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Scada
{
    [DataContract]
    public class TagValue
    {
        
        public enum TagType
        {
            INPUT,OUTPUT
        }
        [Key]
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string TagId { get; set; }
        [DataMember]
        public TagType Type { get; set; }
        [DataMember]
        public double currentValue { get; set; }
        [DataMember]
        public DateTime Time { get; set; }
    }
}