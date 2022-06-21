using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BackEnd.Entities
{
    public partial class PWAKContext : DbContext
    {

        public PWAKContext()
        {
        }

        public PWAKContext(DbContextOptions<PWAKContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bitacora> Bitacoras { get; set; } = null!;
        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<Ejercicio> Ejercicios { get; set; } = null!;
        public virtual DbSet<HistoricoRutina> HistoricoRutinas { get; set; } = null!;
        public virtual DbSet<HistoricoRutinaEjer> HistoricoRutinaEjers { get; set; } = null!;
        public virtual DbSet<Rol> Rols { get; set; } = null!;
        public virtual DbSet<Rutina> Rutinas { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=AGSC465DVT\SQLEXPRESS;Database=PWAK;Integrated Security=True;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bitacora>(entity =>
            {
                entity.HasKey(e => e.IdEvento);

                entity.ToTable("Bitacora");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Bitacoras)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Bitacora_Usuario");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente);

                entity.ToTable("Cliente");

                entity.Property(e => e.Apellido1)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Apellido2)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Cedula)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.IdRol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cliente_Rol");
            });

            modelBuilder.Entity<Ejercicio>(entity =>
            {
                entity.HasKey(e => e.IdEjercicio);

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NombreEjercicio)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<HistoricoRutina>(entity =>
            {
                entity.HasKey(e => e.IdHistRutina);

                entity.ToTable("HistoricoRutina");

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.HasOne(d => d.IdRutinaNavigation)
                    .WithMany(p => p.HistoricoRutinas)
                    .HasForeignKey(d => d.IdRutina)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HistoricoRutina_Rutina");
            });

            modelBuilder.Entity<HistoricoRutinaEjer>(entity =>
            {
                entity.HasKey(e => e.IdHisRutEjer);

                entity.ToTable("HistoricoRutinaEjer");

                entity.HasOne(d => d.IdEjercicioNavigation)
                    .WithMany(p => p.HistoricoRutinaEjers)
                    .HasForeignKey(d => d.IdEjercicio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HistoricoRutinaEjer_Ejercicio");

                entity.HasOne(d => d.IdHistRutinaNavigation)
                    .WithMany(p => p.HistoricoRutinaEjers)
                    .HasForeignKey(d => d.IdHistRutina)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HistoricoRutinaEjer_HistoricoRutina");
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.HasKey(e => e.IdRol);

                entity.ToTable("Rol");

                entity.Property(e => e.IdRol).ValueGeneratedNever();

                entity.Property(e => e.NombreRol)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Rutina>(entity =>
            {
                entity.HasKey(e => e.IdRutina);

                entity.ToTable("Rutina");

                entity.Property(e => e.NombreRutina)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Rutinas)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Rutina_Cliente");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Rutinas)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Rutina_Usuario");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK_Instructor");

                entity.ToTable("Usuario");

                entity.Property(e => e.Apellido1)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Apellido2)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdRol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuario_Rol");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
