using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mobileFoodAPI.Models
{
    public class UsersModel
    {
        public UsersModel(Users users)
        {
            Code_User = users.Code_User;
            Telephone_User = users.Telephone_User;
            Password_User = users.Password_User;
        }

        public int Code_User { get; set; }
        public string Telephone_User { get; set; }
        public int Password_User { get; set; }
    }
}