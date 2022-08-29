using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicationMachineLearning.Service.Interface
{
    public interface IEvaluarImagenService
    {
        void EvaluarImagen ();
        string GuardarImagen(IFormFile file, string path);
        object EvaluarImagen(string pathDevuelto);
    }
}
