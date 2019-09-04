using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class IToken
    {
        public string token { get; set; }

        public string role { get; set; }
    }
}
