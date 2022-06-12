using System;
using System.Collections.Generic;

#nullable disable

namespace AplicacionMachineLearning.Entity
{
    public partial class EvaluarComentario
    {
        public int IdEvaluarComentario { get; set; }
        public string Descripcion { get; set; }
        public double Porcentaje { get; set; }
        public bool Valor { get; set; }
    }
}
