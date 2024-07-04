using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Prueba_Scaffollding.Domain
{
    public partial class DbContextTest : DbContext
    {
        public DbContextTest()
        {
        }

        public DbContextTest(DbContextOptions<DbContextTest> options)
            : base(options)
        {
        }

        public virtual DbSet<Articulo> Articulos { get; set; } = null!;
        public virtual DbSet<Auditoria> Auditorias { get; set; } = null!;
        public virtual DbSet<Barrio> Barrios { get; set; } = null!;
        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<DetalleFactura> DetalleFacturas { get; set; } = null!;
        public virtual DbSet<Factura> Facturas { get; set; } = null!;
        public virtual DbSet<HistorialPrecio> HistorialPrecios { get; set; } = null!;
        public virtual DbSet<Vendedore> Vendedores { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-UUMMIAU\\SQLEXPRESS;Initial Catalog=LIBRERIA_LCI2023;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Articulo>(entity =>
            {
                entity.HasKey(e => e.CodArticulo);

                entity.ToTable("articulos");

                entity.Property(e => e.CodArticulo).HasColumnName("cod_articulo");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Observaciones)
                    .HasMaxLength(50)
                    .HasColumnName("observaciones");

                entity.Property(e => e.PreUnitario)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("pre_unitario");

                entity.Property(e => e.Stock).HasColumnName("stock");

                entity.Property(e => e.StockMinimo).HasColumnName("stock_minimo");
            });

            modelBuilder.Entity<Auditoria>(entity =>
            {
                entity.ToTable("auditorias");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CodEntidad).HasColumnName("cod_entidad");

                entity.Property(e => e.Detalle)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("detalle");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha");

                entity.Property(e => e.Movimiento)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("movimiento");

                entity.Property(e => e.Tabla)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("tabla");
            });

            modelBuilder.Entity<Barrio>(entity =>
            {
                entity.HasKey(e => e.CodBarrio);

                entity.ToTable("barrios");

                entity.Property(e => e.CodBarrio)
                    .ValueGeneratedNever()
                    .HasColumnName("cod_barrio");

                entity.Property(e => e.Barrio1)
                    .HasMaxLength(50)
                    .HasColumnName("barrio");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.CodCliente);

                entity.ToTable("clientes");

                entity.Property(e => e.CodCliente).HasColumnName("cod_cliente");

                entity.Property(e => e.Altura).HasColumnName("altura");

                entity.Property(e => e.ApeCliente)
                    .HasMaxLength(50)
                    .HasColumnName("ape_cliente");

                entity.Property(e => e.Calle)
                    .HasMaxLength(50)
                    .HasColumnName("calle");

                entity.Property(e => e.CodBarrio).HasColumnName("cod_barrio");

                entity.Property(e => e.EMail)
                    .HasMaxLength(50)
                    .HasColumnName("e-mail");

                entity.Property(e => e.NomCliente)
                    .HasMaxLength(50)
                    .HasColumnName("nom_cliente");

                entity.Property(e => e.NroTel).HasColumnName("nro_tel");

                entity.HasOne(d => d.CodBarrioNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.CodBarrio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_clientes_barrios");
            });

            modelBuilder.Entity<DetalleFactura>(entity =>
            {
                entity.HasKey(e => new { e.NroFactura, e.CodArticulo })
                    .HasName("PK_detalle");

                entity.ToTable("detalle_facturas");

                entity.Property(e => e.NroFactura).HasColumnName("nro_factura");

                entity.Property(e => e.CodArticulo).HasColumnName("cod_articulo");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.PreUnitario)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("pre_unitario");

                entity.HasOne(d => d.CodArticuloNavigation)
                    .WithMany(p => p.DetalleFacturas)
                    .HasForeignKey(d => d.CodArticulo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_detalle_articulos");

                entity.HasOne(d => d.NroFacturaNavigation)
                    .WithMany(p => p.DetalleFacturas)
                    .HasForeignKey(d => d.NroFactura)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_detalle_facturas");
            });

            modelBuilder.Entity<Factura>(entity =>
            {
                entity.HasKey(e => e.NroFactura);

                entity.ToTable("facturas");

                entity.Property(e => e.NroFactura).HasColumnName("nro_factura");

                entity.Property(e => e.CodCliente).HasColumnName("cod_cliente");

                entity.Property(e => e.CodVendedor).HasColumnName("cod_vendedor");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha");

                entity.HasOne(d => d.CodClienteNavigation)
                    .WithMany(p => p.Facturas)
                    .HasForeignKey(d => d.CodCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_facturas_clientes");

                entity.HasOne(d => d.CodVendedorNavigation)
                    .WithMany(p => p.Facturas)
                    .HasForeignKey(d => d.CodVendedor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_facturas_vendedores");
            });

            modelBuilder.Entity<HistorialPrecio>(entity =>
            {
                entity.ToTable("historial_precios");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CodArticulo).HasColumnName("cod_articulo");

                entity.Property(e => e.FechaDesde)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_desde");

                entity.Property(e => e.FechaHasta)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_hasta");

                entity.Property(e => e.Precio)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("precio");
            });

            modelBuilder.Entity<Vendedore>(entity =>
            {
                entity.HasKey(e => e.CodVendedor);

                entity.ToTable("vendedores");

                entity.Property(e => e.CodVendedor).HasColumnName("cod_vendedor");

                entity.Property(e => e.Altura).HasColumnName("altura");

                entity.Property(e => e.ApeVendedor)
                    .HasMaxLength(50)
                    .HasColumnName("ape_vendedor");

                entity.Property(e => e.Calle)
                    .HasMaxLength(50)
                    .HasColumnName("calle");

                entity.Property(e => e.CodBarrio).HasColumnName("cod_barrio");

                entity.Property(e => e.EMail)
                    .HasMaxLength(50)
                    .HasColumnName("e-mail");

                entity.Property(e => e.FecNac)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("fec_nac");

                entity.Property(e => e.NomVendedor)
                    .HasMaxLength(50)
                    .HasColumnName("nom_vendedor");

                entity.Property(e => e.NroTel).HasColumnName("nro_tel");

                entity.HasOne(d => d.CodBarrioNavigation)
                    .WithMany(p => p.Vendedores)
                    .HasForeignKey(d => d.CodBarrio)
                    .HasConstraintName("FK_vendedores_barrios");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
