using BloknotMVC.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BloknotMVC.Data.Context
{
    public class BloknotDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=BloknotDBMVC;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Record> Records { get; set; }
    }
}
