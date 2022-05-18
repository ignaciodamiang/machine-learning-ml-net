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
                Review_es = comentario,
            };

            //Load model and predict output
            var result = MLModel.Predict(sampleData);

            if (result.Prediction == "positivo")
            {
                mensaje = "Una frase positiva";

            }
            else {
                mensaje = "Una frase negativa";

            }

           

            return View("Resultado", mensaje);
        }

        //Load sample data
       


    }
}
