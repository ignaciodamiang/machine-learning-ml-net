using EF.Data.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Data.Repository.Interface
{
    public interface IEvaluarComentarioRepository
    {
        void GuardarComentario(EvaluarComentario evaluarComentario);
        void Savechange();
        List<EvaluarComentario> ObtenerListaDeComentarios();
        void EliminarSobranteDeLista(EvaluarComentario evaluarComentario);
    }
}
