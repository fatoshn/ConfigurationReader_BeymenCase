using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationReader.Data
{
    public class ConfigurationDbContext : DbContext
    {
        private string _connectionString { get; set; }
        public ConfigurationDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public ConfigurationDbContext(DbContextOptions<ConfigurationDbContext> options) : base(options) { }

        public DbSet<Configuration> ConfigurationModels { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
