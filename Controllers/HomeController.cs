using AplicacionMachineLearning.Data;
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
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;

        public HomeController( IWebHostEnvironment environment)
        {
            _hostingEnvironment = environment;

        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult EvaluarComentario()
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
                mensaje = "Ese fue un comentario Positivo! Muchas gracias por comentar";
            }
            else
            {
                mensaje = "Ese fue un comentario Negativo... lo sentimos!";
            }

            return View("EvaluarComentario", mensaje);
        }

        [HttpGet]
        public IActionResult EvaluarImagen()
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

            return View("EvaluarImagen", prediccion);


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

        public IActionResult EvaluarEmail()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EvaluarEmail(SpamInput input)
        {
            var model = new SpamModel();
            model.Build();
            model.Train();
            ViewBag.Prediction = model.Predict(input);
            return View();
        }
    }





}

