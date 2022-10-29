using Microsoft.EntityFrameworkCore;
using WatchfulEye.Models;

namespace WatchfulEye.Data
{
    public class WatchfulEyeContext : DbContext
    {

        public WatchfulEyeContext(DbContextOptions<WatchfulEyeContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=WatchfulEye1");
        }

        public DbSet<EmailTemplate> emailTemplates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmailTemplate>().ToTable("Email");
        }
    }
}
