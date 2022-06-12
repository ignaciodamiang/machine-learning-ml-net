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
        public DbSet<EvaluarComentarioView> Comentarios { get; set; }
    }
}
