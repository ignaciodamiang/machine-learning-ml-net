using AplicacionMachineLearning.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AplicacionMachineLearning.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public IActionResult EvaluarComentario(string comentario)
        {
            string mensaje;
            //Load sample data
            var sampleData = new MLModel.ModelInput()
            {
                Col0 = comentario,
            };

            //Load model and predict output
            var result = MLModel.Predict(sampleData);

            if (result.Score[0] > result.Score[1])
            {
                mensaje = "Una frase negativa";
            }
            else
            {
                mensaje = "Una frase positiva";
            }

            return View("Resultado", mensaje);
        }


    }
}
