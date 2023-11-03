using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ApiChallenge.Models;

namespace ApiChallenge.DBContext
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Producto> Productos { get; set; } = null!;
        public virtual DbSet<TiposProducto> TiposProductos { get; set; } = null!;



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TiposProducto>(entity =>
            {
                entity.HasKey(e => e.TipoProductoId)
                    .HasName("PK__TiposPro__FB00758A8F6A2234");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
