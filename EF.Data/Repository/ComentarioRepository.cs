using EF.Data.EF;
using EF.Data.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Data.Repository
{
    public class ComentarioRepository : IComentarioRepository
    {
        private MLdataBaseContext _ctx;

        public ComentarioRepository(MLdataBaseContext ctx)
        {
            _ctx = ctx;
        }

        public void EliminarSobranteDeLista(EvaluarComentario evaluarComentario)
        {
            _ctx.Remove(evaluarComentario);
        }

        public void GuardarComentario(EvaluarComentario evaluarComentario)
        {
            _ctx.EvaluarComentarios.Add(evaluarComentario);
        }

        public List<EvaluarComentario> ObtenerListaDeComentarios()
        {
            return _ctx.EvaluarComentarios.OrderByDescending(o => o.IdEvaluarComentario).Take(10).ToList();
        }

        public void Savechange()
        {
            _ctx.SaveChanges();
        }
    }
}
