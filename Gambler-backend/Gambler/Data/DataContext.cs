namespace Gambler.PoC.Data
{
    using Gambler.PoC.Business.Entities;
    using Microsoft.EntityFrameworkCore;
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        { 
            //Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        // Best dataset ever
        public DbSet<Gambler> Gamblers { get; set; }

    }
}
