using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Scada
{
    public class TagValueContext: DbContext
    {
        public DbSet<TagValue> TagValues { get; set; }

        public TagValueContext()
        {

        }
    }
}