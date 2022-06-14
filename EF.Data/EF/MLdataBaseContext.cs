using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace EF.Data.EF
{
    public partial class MLdataBaseContext : DbContext
    {
        public MLdataBaseContext()
        {
        }

        public MLdataBaseContext(DbContextOptions<MLdataBaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EvaluarComentario> EvaluarComentarios { get; set; }
        public virtual DbSet<Mensaje> Mensajes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=MLdataBase;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<EvaluarComentario>(entity =>
            {
                entity.HasKey(e => e.IdEvaluarComentario)
                    .HasName("PK__evaluar___7A091143A80C6102");

                entity.ToTable("evaluar_comentario");

                entity.Property(e => e.IdEvaluarComentario).HasColumnName("id_evaluar_comentario");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Porcentaje).HasColumnName("porcentaje");

                entity.Property(e => e.Valor).HasColumnName("valor");
            });

            modelBuilder.Entity<Mensaje>(entity =>
            {
                entity.HasKey(e => e.IdMensaje)
                    .HasName("PK__Mensaje__5B37C7F666996B76");

                entity.ToTable("Mensaje");

                entity.Property(e => e.IdMensaje).HasColumnName("id_mensaje");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Valor).HasColumnName("valor");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
