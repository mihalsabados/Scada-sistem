using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Scada
{
    public class User
    {
        [Key]
        public string Username { get; set; }
        public string EncryptedPassword { get; set; }

        public User()
        {
        }

        public User(string username, string encryptedPassword)
        {
            Username = username;
            EncryptedPassword = encryptedPassword;
        }
    }
}