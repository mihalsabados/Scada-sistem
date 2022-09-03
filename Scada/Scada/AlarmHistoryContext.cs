using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Scada
{
    public class AlarmHistoryContext:DbContext
    {
        public DbSet<AlarmHistory> alarmHistories { get; set; }

        public AlarmHistoryContext()
        {

        }
    }
}