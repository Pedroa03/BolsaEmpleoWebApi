using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Capa_Entidad
{
    public partial class BolsaEmpleoDBContext : DbContext
    {
        public BolsaEmpleoDBContext()
        {
        }

        public BolsaEmpleoDBContext(DbContextOptions<BolsaEmpleoDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<DetalleAplicacion> DetalleAplicacions { get; set; }
        public virtual DbSet<Jornada> Jornada { get; set; }
        public virtual DbSet<Puesto> Puestos { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuarios { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }



        //Este codigo fue lo movi al Api en la clase Startup

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Data Source=MASDLTP08\\SQLEXPRESS;Initial Catalog=BolsaEmpleoDB;Persist Security Info=True;User ID=sa;Password=1234;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion).HasMaxLength(50);
            });

            modelBuilder.Entity<DetalleAplicacion>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("DetalleAplicacion");

                entity.Property(e => e.DetalleAplicacionPuesto).HasMaxLength(50);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.IdPuesto).HasColumnName("idPuesto");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.HasOne(d => d.IdPuestoNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdPuesto)
                    .HasConstraintName("FK_DetalleAplicacion_Puesto");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK_DetalleAplicacion_Usuario");
            });

            modelBuilder.Entity<Jornada>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion).HasMaxLength(50);
            });

            modelBuilder.Entity<Puesto>(entity =>
            {
                entity.HasKey(e => e.IdPuestos);

                entity.ToTable("Puesto");

                entity.Property(e => e.IdPuestos).HasColumnName("idPuestos");

                entity.Property(e => e.Compañia)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.CorreoContacto).HasMaxLength(100);

                entity.Property(e => e.Descripcion).HasMaxLength(600);

                entity.Property(e => e.IdCategoria).HasColumnName("idCategoria");

                entity.Property(e => e.IdTipoJornada).HasColumnName("idTipoJornada");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Logo).HasMaxLength(800);

                entity.Property(e => e.Posicion)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Ubicacion).HasMaxLength(200);

                entity.Property(e => e.Url).HasMaxLength(500);

                entity.HasOne(d => d.TipoJornada)
                    .WithMany(p => p.Puestos)
                    .HasForeignKey(d => d.IdTipoJornada)
                    .HasConstraintName("FK_Puesto_Jornada");

                //entity.HasOne(d => d.Usuario)
                //    .WithMany(p => p.)
                //    .HasForeignKey(d => d.IdUsuario)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_Puesto_Usuario");
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.ToTable("TipoUsuario");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion).HasMaxLength(50);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.ToTable("Usuario");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Apellido).HasMaxLength(50);

                entity.Property(e => e.Clave)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Correo).HasMaxLength(100);

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.IdCategoria).HasColumnName("idCategoria");

                entity.Property(e => e.IdTipoUsuario).HasColumnName("idTipoUsuario");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Categoria)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdCategoria)
                    .HasConstraintName("FK_Usuario_Categoria");

                entity.HasOne(d => d.TipoUsuario)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuario_TipoUsuario");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
