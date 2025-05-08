using Loaylty.Infrastructure.Common;
using Loyalty.Domain.Users;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using System.Reflection.Metadata;

namespace Loaylty.Infrastructure
{
    public class LoayltyContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public string DbPath { get; }

        public LoayltyContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "LoyaltySystem.db");
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}")
            ;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyAllConfigurations();

            base.OnModelCreating(modelBuilder);
        }
    }
}
