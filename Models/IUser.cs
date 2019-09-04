using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class IUser
    {
        public string email { get; set; }

        public string password { get; set; }
    }
}
