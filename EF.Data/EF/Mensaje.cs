using System;
using System.Collections.Generic;

#nullable disable

namespace EF.Data.EF
{
    public partial class Mensaje
    {
        public int IdMensaje { get; set; }
        public string Descripcion { get; set; }
        public bool Valor { get; set; }
    }
}
