using EF.Data.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Data.Repository.Interface
{
    public interface IEvaluarImagenRepository
    {
        void GuardarImagen(EvaluarImagen evaluarImagen);
    }
}
