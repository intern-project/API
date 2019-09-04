using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class IEmployee
    {
        public int id { get; set; }
       
        public string email { get; set; }

        public string password { get; set; }

        public string role { get; set; }
    }
}