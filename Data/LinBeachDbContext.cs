using LinBeach.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace LinBeach.Data
{
    public class LinBeachDbContext: DbContext
    {
        public LinBeachDbContext(DbContextOptions<LinBeachDbContext> options) : base(options) 
        { 
        }

        public DbSet<EventPost> EventPosts { get; set; }
    }
}
