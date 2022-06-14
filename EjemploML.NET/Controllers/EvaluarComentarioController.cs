using AplicationMachineLearning.Service.Interface;
using EF.Data.EF;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AplicacionMachineLearning.Controllers
{
    public class EvaluarComentarioController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private IEvaluarComentarioService _evaluarComentarioService;

        public EvaluarComentarioController(IWebHostEnvironment environment, IEvaluarComentarioService evaluarComentarioService)
        {
            _hostingEnvironment = environment;
            _evaluarComentarioService = evaluarComentarioService;
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
            ViewBag.Mensaje = _evaluarComentarioService.EvaluarComentarios(comentario);
            List<EvaluarComentario> listComentarios = _evaluarComentarioService.ObtenerListaDeComentarios();

            return View("Index", listComentarios);
        }
    }
}
