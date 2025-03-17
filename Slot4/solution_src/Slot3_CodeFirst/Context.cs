using libData.Db;
using Microsoft.EntityFrameworkCore;
using Slot3_CodeFirst.Db.Models;

namespace Slot3_CodeFirst
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<Player> Players { get; set; }
        public DbSet<InstrumentType> InstrumentTypes { get; set; }
        public DbSet<PlayerInstrument> PlayerInstrumentTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>()
                .HasMany(i => i.Instruments)
                .WithOne();

            modelBuilder.Seed(); //bình thường thay vì khai báo data ở đây, ta có thể sử dụng phương thức Seed
        }
    }
}
