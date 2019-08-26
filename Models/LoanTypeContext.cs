using Microsoft.EntityFrameworkCore;

namespace API.Models
{
    public class LoanTypeContext : DbContext
    {
        public LoanTypeContext(DbContextOptions<LoanTypeContext> options)
            : base(options)
        {
        }

        public DbSet<LoanType> LoanTypes { get; set; }
    }
}