using System.ComponentModel.DataAnnotations;


namespace API.Models
{
    public class LoanType
    {
        public int id { get; set; }
        public string label { get; set; }
        public double rate { get; set; }


    }

}