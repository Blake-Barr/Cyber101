using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WatchfulEye.Models;
using WatchfulEye.Models.Simulator;

namespace WatchfulEye.Data
{
    public class WatchfulEyeContext : IdentityDbContext<AppUser>
    {

        public WatchfulEyeContext(DbContextOptions<WatchfulEyeContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=WatchfulEye1");
        }

        public DbSet<EmailTemplate> emailTemplates { get; set; }
        public DbSet<FakeSite> fakeSites { get; set; }
        public DbSet<SimulatorLevel> simLevels { get; set; }
        public DbSet<SimulatorLevelContent> simContent{ get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmailTemplate>().ToTable("Email");
            modelBuilder.Entity<FakeSite>().ToTable("FakeSite");
            modelBuilder.Entity<AppUser>().ToTable("AppUser");
            base.OnModelCreating(modelBuilder);
        }
    }
}
