using LearnEngine.Core.Entities.SQL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnEngine.Infrastucture.Context
{
    public class LearnEngineDbContext : DbContext
    {
        public LearnEngineDbContext(DbContextOptions<LearnEngineDbContext> options) : base(options)
        {
        }

        //public DbSet<Material> Materials { get; set; }
        //public DbSet<MaterialRelations> Relations { get; set; }
        public DbSet<Relation> Relation { get; set; }
        public DbSet<Material> Material { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Relation>()
                .HasKey(e => new { e.ParentId, e.MaterialId });

            modelBuilder.Entity<Relation>()
                .HasOne(e => e.Parent)
                .WithMany(e => e.Children)
                .HasForeignKey(e => e.ParentId)
                .OnDelete(DeleteBehavior.NoAction);

            //modelBuilder.Entity<Relation>()
            //    .HasOne(e => e.Material)
            //    .WithMany(e => e.Parents)
            //    .HasForeignKey(e => e.MaterialId)
            //    .OnDelete(DeleteBehavior.NoAction);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("SQL");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
