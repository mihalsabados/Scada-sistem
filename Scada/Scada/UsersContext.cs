using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Scada
{
    public class UsersContext:DbContext
    {
        public DbSet<User> Users { get; set; }

        public UsersContext()
        {
        }
    }
}