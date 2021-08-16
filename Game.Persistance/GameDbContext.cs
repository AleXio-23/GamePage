using Game.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Persistance
{
    public partial class GameDbContext : DbContext
    {
        public GameDbContext()
        {

        }

        public GameDbContext(DbContextOptions<GameDbContext> options)
               : base(options)
        {

        }

        public virtual DbSet<Domain.Models.Game> Games { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<GameCategory> GameCategories { get; set; }
        public virtual DbSet<VwGameCategories> VwGameCategories { get; set; }


        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Domain.Models.Game>(entity => {
                entity.ToTable("Games", "dbo");

                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.ImageUrl).HasMaxLength(255);
                entity.Property(e => e.GameUrl).HasMaxLength(255);
            });


            modelBuilder.Entity<Category>(entitry => {
                entitry.ToTable("Categories", "dbo");

                entitry.Property(e => e.Name).IsRequired().HasMaxLength(100);
            });

            modelBuilder.Entity<VwGameCategories>(entity => {
                entity.ToView("vwGameCategories", "dbo");
            });


            modelBuilder.Entity<GameCategory>(entitry => {
                entitry.ToTable("Game-Categories", "dbo");

                entitry.HasOne(e => e.Game)
                    .WithMany(e => e.GameCategories)
                    .HasForeignKey(f => f.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull);


                entitry.HasOne(e => e.Category)
                    .WithMany(e => e.GameCategories)
                    .HasForeignKey(f => f.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

            });
        }
    }
}
