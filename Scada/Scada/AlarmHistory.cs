using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Scada
{
    public class AlarmHistory
    {
        [Key]
        public int Id { get; set; }
        public string TagId { get; set; }
        public string Type { get; set; }
        public double Limit { get; set; }
        public int Priority { get; set; }
        public DateTime Time { get; set; }
    }
}