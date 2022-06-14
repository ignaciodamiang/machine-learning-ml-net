using EF.Data.EF;
using EF.Data.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Data.Repository
{
    public class EvaluarImagenRepository : IEvaluarImagenRepository
    {
        private MLdataBaseContext _ctx;
        public EvaluarImagenRepository(MLdataBaseContext ctx)
        {
            _ctx = ctx;
        }

        public void GuardarImagen(EvaluarImagen evaluarImagen)
        {
            throw new NotImplementedException();
        }
    }
    
}
