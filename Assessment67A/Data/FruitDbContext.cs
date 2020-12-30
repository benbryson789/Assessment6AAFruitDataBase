using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Assessment67A.Data
{
    public partial class FruitDbContext : DbContext
    {
        public FruitDbContext()
        {
        }

        public FruitDbContext(DbContextOptions<FruitDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Fruit> Fruit { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("server=LAPTOP-1QFGMM00\\SQLEXPRESS; database=FruitDb; Trusted_connection=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fruit>(entity =>
            {
                entity.Property(e => e.Color).HasMaxLength(40);

                entity.Property(e => e.Name).HasMaxLength(40);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
