using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AplicacionMachineLearning.Model
{
    public class MiContexto : DbContext
    {
        public MiContexto() { }

        public MiContexto(DbContextOptions<MiContexto> options)
            : base(options)
        {
        }
        public DbSet<EvaluarComentarioViewModel> Comentarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=MachineLearningDB;Integrated Security=True");
            }
        }
    }
}
