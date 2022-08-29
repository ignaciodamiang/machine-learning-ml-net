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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=MLdataBase;Trusted_Connection=True; ");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<EvaluarComentario>(entity =>
            {
                entity.HasKey(e => e.IdEvaluarComentario)
                    .HasName("PK__evaluar___7A091143E4B30C21");

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

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
