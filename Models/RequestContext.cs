using Microsoft.EntityFrameworkCore;

namespace API.Models
{
    public class RequestContext : DbContext
    {
        public RequestContext(DbContextOptions<RequestContext> options)
            : base(options)
        {
        }

        public DbSet<Request> Requests { get; set; }
    }
}