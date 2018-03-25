using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BakeryProject.Models
{
    public class LoginClass
    {
        public LoginClass() { }

        public LoginClass(string email, string password)
        {
            PersonEmail = email;
            PersonPhone = password;
        }

        public string PersonEmail { set; get; }
        public string PersonPhone { set; get; }
    }
}