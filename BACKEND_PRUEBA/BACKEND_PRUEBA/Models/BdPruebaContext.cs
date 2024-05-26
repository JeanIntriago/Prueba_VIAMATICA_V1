using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BACKEND_PRUEBA.Models
{
    public partial class BdPruebaContext : DbContext
    {
        public BdPruebaContext()
        {
        }

        public BdPruebaContext(DbContextOptions<BdPruebaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<OrdenCompra> OrdenesCompra { get; set; }
        public virtual DbSet<OrdenCompraDetalle> OrdenCompraDetalles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.IdCategoria).HasName("PK__Categori__8A3D240C01FF34F7");

                entity.Property(e => e.IdCategoria).HasColumnName("idCategoria");
                entity.Property(e => e.NombreCategoria)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombreCategoria");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.IdProducto).HasName("PK__Producto__07F4A132EDFA1B62");

                entity.ToTable("Producto");

                entity.Property(e => e.IdProducto).HasColumnName("idProducto");
                entity.Property(e => e.NombreProducto)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombreProducto");
                entity.Property(e => e.Precio).HasColumnName("precio");
                entity.Property(e => e.Cantidad).HasColumnName("cantidad");
                entity.Property(e => e.IdCategoria).HasColumnName("idCategoria");

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.IdCategoria)
                    .HasConstraintName("FK_Producto_Categoria");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdCliente).HasName("PK__Usuario__885457EECDA00636");

                entity.ToTable("Usuario");

                entity.Property(e => e.IdCliente).HasColumnName("idCliente");
                entity.Property(e => e.Apellido)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("apellido");
                entity.Property(e => e.Clave)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("clave");
                entity.Property(e => e.Correo)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("correo");
                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<OrdenCompra>(entity =>
            {
                entity.HasKey(e => e.IdOrden).HasName("PK__OrdenCompra");

                entity.ToTable("OrdenCompra");

                entity.Property(e => e.IdOrden).HasColumnName("idOrden");
                entity.Property(e => e.Total)
                    .HasColumnName("total")
                    .HasColumnType("decimal(18, 2)");
                entity.Property(e => e.FechaRegistro)
                    .HasColumnName("fechaRegistro")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.HasMany(e => e.OrdenCompraDetalles)
                    .WithOne(e => e.OrdenCompra)
                    .HasForeignKey(e => e.IdOrden)
                    .HasConstraintName("FK_OrdenCompra_OrdenCompraDetalles");
            });

            modelBuilder.Entity<OrdenCompraDetalle>(entity =>
            {
                entity.HasKey(e => e.IdOrdenDetalle).HasName("PK__OrdenCompraDetalle");

                entity.ToTable("OrdenCompraDetalle");

                entity.Property(e => e.IdOrdenDetalle).HasColumnName("idOrdenDetalle");
                entity.Property(e => e.IdOrden).HasColumnName("idOrden");
                entity.Property(e => e.IdProducto).HasColumnName("idProducto");

                entity.HasOne(d => d.OrdenCompra)
                    .WithMany(p => p.OrdenCompraDetalles)
                    .HasForeignKey(d => d.IdOrden)
                    .HasConstraintName("FK_OrdenCompraDetalle_OrdenCompra");

                entity.HasOne(d => d.Producto)
                    .WithMany(p => p.OrdenCompraDetalles)
                    .HasForeignKey(d => d.IdProducto)
                    .HasConstraintName("FK_OrdenCompraDetalle_Producto");
            });

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
