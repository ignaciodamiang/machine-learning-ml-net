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
    public class EvaluarComentarioController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        MiContexto contexto;
        public EvaluarComentarioController(IWebHostEnvironment environment)
        {
            _hostingEnvironment = environment;
            contexto = new MiContexto();
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
                mensaje = "Ese fue un comentario Positivo! Muchas gracias por comentar";
            }
            else
            {
                mensaje = "Ese fue un comentario Negativo... lo sentimos!";
            }

            return View("Index", mensaje);
        }

        [HttpPost]
        public ActionResult Create(EvaluarComentarioViewModel nuevoComentario)
        {
            if (nuevoComentario is null)
            {
                throw new ArgumentNullException(nameof(nuevoComentario));
            }

            contexto.Comentarios.Add(nuevoComentario);
            contexto.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EvaluarComentario()
        {
            return View();
        }
    }
}
