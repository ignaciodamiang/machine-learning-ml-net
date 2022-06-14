using AplicationMachineLearning.Service.Interface;
using EF.Data.EF;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;

namespace AplicacionMachineLearning.Controllers
{
    public class EvaluarImagenController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private IEvaluarImagenService _evaluarImagenService;
        public EvaluarImagenController(IWebHostEnvironment environment, IEvaluarImagenService evaluarImagenService)
        {
            _hostingEnvironment = environment;
            _evaluarImagenService = evaluarImagenService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult EvaluarImagen()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EvaluarImagen(IFormFile file)
        {
            string path = _evaluarImagenService.GuardarImagen(file);
            // string path = GuardarImagen(file);

            var sampleData = new MLImagenes.ModelInput()
            {
                ImageSource = path,
            };
            //Load model and predict output
            var result = MLImagenes.Predict(sampleData);
            string prediccion = result.Prediction;
            System.IO.File.Delete(path);
            return View("EvaluarImagen", prediccion);
        }

        [HttpPost]
        public string GuardarImagen(IFormFile file)
        {

            string path = _hostingEnvironment.WebRootPath;

            return _evaluarImagenService.GuardarImagen(file, path);
        }
    }
}
