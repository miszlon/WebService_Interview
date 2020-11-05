using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Task_Junior_1._2.Models
{
    public partial class Task_JuniorContext : DbContext
    {
        public Task_JuniorContext()
        {
        }

        public Task_JuniorContext(DbContextOptions<Task_JuniorContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Author { get; set; }
        public virtual DbSet<Blog> Blog { get; set; }
        public virtual DbSet<Post> Post { get; set; }
        public virtual DbSet<User> User { get; set; }

      

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=Task_Junior");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>(entity =>
            {
                entity.Property(e => e.FirstName).HasMaxLength(20);

                entity.Property(e => e.LastName).HasMaxLength(30);
            });

            modelBuilder.Entity<Blog>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(30);
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Title).HasMaxLength(20);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Password).IsRequired();

                entity.Property(e => e.Username).HasMaxLength(20);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
