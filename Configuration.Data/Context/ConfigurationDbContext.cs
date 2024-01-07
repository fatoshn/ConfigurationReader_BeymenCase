using Configuration.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Configuration.Data.Context
{
    public class ConfigurationDbContext: DbContext
    {
        public ConfigurationDbContext(DbContextOptions<ConfigurationDbContext> options): base(options) { }

        public DbSet<ConfigurationModel> ConfigurationModels{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConfigurationModel>().Property(_ => _.RowVersion).IsRowVersion();
        }
    }
}
