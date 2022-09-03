using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Scada
{
    public class DO:OutputTag
    {
        public DO(string id, string description, string address, double initValue)
        {
            Id = id;
            Description = description;
            Address = address;
            InitValue = initValue;
        }
    }
}