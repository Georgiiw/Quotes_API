using Microsoft.EntityFrameworkCore;
using QuotesAPI.Data.Models;

namespace QuotesAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<Quote> Quotes { get; set; }
    }
}
