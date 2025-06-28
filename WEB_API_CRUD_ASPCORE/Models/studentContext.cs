using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WEB_API_CRUD_ASPCORE.Models
{
    public partial class studentContext : DbContext
    {
        public studentContext()
        {
        }

        public studentContext(DbContextOptions<studentContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<StudentCrud> StudentCruds { get; set; } = null!;
        public virtual DbSet<Studentdatum> Studentdata { get; set; } = null!;
        public DbSet<User> Users { get; set; }  

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
 
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("student");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.English).HasColumnName("english");

                entity.Property(e => e.Math).HasColumnName("math");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<StudentCrud>(entity =>
            {
                entity.ToTable("StudentCrud");

                entity.Property(e => e.DateOfBirth)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Date_of_Birth");

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Language)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Studentdatum>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("studentdata");

                entity.Property(e => e.Dateofbirth).HasColumnType("date");

                entity.Property(e => e.Id).HasColumnName("id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
