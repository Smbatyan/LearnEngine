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

        public DbSet<CompactMaterial> Materials { get; set; }

        public DbSet<Relation> Relations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Relation>().HasNoKey();

            //modelBuilder.Entity<Node>()
            //    .HasOne(pt => pt.Id)
            //    .WithMany(p => p.)
            //    .HasForeignKey(pt => pt.StatusId);

            //modelBuilder.Entity<Node>()
            //    .HasMany(p => p.SubNodes)
            //    .WithMany(p => p.ParentNodes);
            //    //.HasForeignKey(p => p.)
            //    //.HasPrincipalKey(p=> p.Id);
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
