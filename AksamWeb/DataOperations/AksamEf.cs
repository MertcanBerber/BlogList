using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AksamWeb.DataOperations
{
    public class AksamEf:IdentityDbContext
    {
        public AksamEf(DbContextOptions options):base(options) { 
        
        }
        public DbSet<Entities.BlogPost> BlogPosts { get; set; }
    }
}
