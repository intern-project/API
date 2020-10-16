using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Request
    {
        [Key]
        public int rid { get; set; }
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
        public int pending { get; set; }
        public int accepted { get; set; }
        public int declined { get; set; }
        public int userId { get; set; }
        public int rowId { get; set; }
    }
}