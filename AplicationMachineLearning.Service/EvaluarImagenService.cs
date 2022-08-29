using AplicationMachineLearning.Service.Interface;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace AplicationMachineLearning.Service
{
    public class EvaluarImagenService : IEvaluarImagenService
    {
        public void EvaluarImagen()
        {
            throw new NotImplementedException();
        }

        public object EvaluarImagen(string pathDevuelto)
        {
            throw new NotImplementedException();
        }

        public string GuardarImagen(IFormFile file, string path)
        {
            string uploads = Path.Combine(path, "uploads");
            string filepath = "";
            if (file.Length > 0)
            {
                filepath = Path.Combine(uploads, file.FileName);
                using (Stream fileStream = new FileStream(filepath, FileMode.Create))

                    file.CopyToAsync(fileStream);
            }
            return filepath;
        }

    }
}
