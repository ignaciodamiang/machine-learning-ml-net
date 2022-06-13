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
        private IComentarioService _comentarioService;

        public EvaluarComentarioController(IWebHostEnvironment environment, IComentarioService comentarioService)
        {
            _hostingEnvironment = environment;
            _comentarioService = comentarioService;
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
            ViewBag.Mensaje = _comentarioService.EvaluarComentarios(comentario);
            List<EvaluarComentario> listComentarios = _comentarioService.ObtenerListaDeComentarios();

            return View("EvaluarComentario", listComentarios);
        }
    }
}
