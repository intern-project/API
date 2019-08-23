using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace API.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RequestContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<RequestContext>>()))
            {
                // Look for any requests.
                if (context.Request.Any())
                {
                    return;   // DB has been seeded
                }

                context.Request.AddRange(
                    new Request
                    {
                        rid = "4",
                        name = "saman",
                        nic = "961411840V",
                        address = "pasyala",
                        contact = "0332357946",
                        job = "se",
                        age = "23",
                        doc = "",
                        reason = "",
                        ammount = "",
                        duration = 4,
                        pending = 1,
                        accepted = 0,
                        declined = 0
                    },

                    new Request
                    {
                        rid = "5",
                        name = "Kuma",
                        nic = "951411840V",
                        address = "Colombo 06",
                        contact = "0112357946",
                        job = "se",
                        age = "23",
                        doc = "",
                        reason = "",
                        ammount = "",
                        duration = 4,
                        pending = 1,
                        accepted = 0,
                        declined = 0
                    },

                    new Request
                    {
                        rid = "6",
                        name = "Nuwan",
                        nic = "961411840V",
                        address = "Kandy",
                        contact = "0312357946",
                        job = "se",
                        age = "23",
                        doc = "",
                        reason = "",
                        ammount = "",
                        duration = 4,
                        pending = 1,
                        accepted = 0,
                        declined = 0
                    },

                    new Request
                    {
                        rid = "7",
                        name = "Ruwan",
                        nic = "961411840V",
                        address = "Galle",
                        contact = "0222357946",
                        job = "se",
                        age = "23",
                        doc = "",
                        reason = "",
                        ammount = "",
                        duration = 4,
                        pending = 1,
                        accepted = 0,
                        declined = 0
                    }
                );
                context.SaveChanges();
            }
        }
    }
}