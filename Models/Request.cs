using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Request
    {
        [Key]
        public long rid { get; set; }
        public string name { get; set; }
        public string nic { get; set; }
        public string address { get; set; }
        public string contact { get; set; }
        public string job { get; set; }
        public string age { get; set; }
        public string reason { get; set; }
        public string doc { get; set; }
        public string ammount { get; set; }
        public string duration { get; set; }
        public bool pending { get; set; }
        public bool accepted { get; set; }
        public bool declined { get; set; }
    }
}