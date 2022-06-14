using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicationMachineLearning.Service.Interface
{
    internal interface IEvaluarImagenService
    {
        void EvaluarImagen ();
        string GuardarImagen(IFilePath file, string path);
    }
}
