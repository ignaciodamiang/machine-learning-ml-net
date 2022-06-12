using AplicacionMachineLearning.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServiceStack;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AplicacionMachineLearning.Controllers
{
    public class EvaluarImagenController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;

        public EvaluarImagenController(IWebHostEnvironment environment)
        {
            _hostingEnvironment = environment;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EvaluarImagen(IFormFile file)
        {
            string path = GuardarImagen(file);

            var sampleData = new MLImagenes.ModelInput()
            {

                ImageSource = path,
            };

            //Load model and predict output
            var result = MLImagenes.Predict(sampleData);
            string prediccion = result.Prediction;

            System.IO.File.Delete(path);

            return View("Index", prediccion);


        }

        [HttpPost]
        public string GuardarImagen(IFormFile file)
        {
            string uploads = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
            string filepath = "";
            if (file.Length > 0)
            {
                filepath = Path.Combine(uploads, file.FileName);
                using (Stream fileStream = new FileStream(filepath, FileMode.Create))

                    file.CopyToAsync(fileStream);


            }

            return filepath;

        }

        [HttpGet]
        public IActionResult EvaluarImagen()
        {

            return View();
        }
    }
}
