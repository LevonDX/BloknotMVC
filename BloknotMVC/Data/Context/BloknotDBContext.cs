using BloknotMVC.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BloknotMVC.Data.Context
{
    public class BloknotDBContext : DbContext
    {
        public DbSet<Record> Records { get; set; }

        public BloknotDBContext(DbContextOptions<BloknotDBContext> options) 
            : base(options)
        {

        }
    }
}
