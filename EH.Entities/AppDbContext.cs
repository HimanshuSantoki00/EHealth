using EH.Entities.Entities.DbEntities;
using Microsoft.EntityFrameworkCore;

namespace EH.Entities
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public DbSet<UserContact> Contacts { get; set; }
    }
}
