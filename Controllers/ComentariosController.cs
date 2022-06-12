using System;
using System.Linq;
using AplicacionMachineLearning.Model;
using Microsoft.AspNetCore.Mvc;

namespace AplicacionMachineLearning.Controllers
{
    public class ComentariosController : Controller
    {
        MiContexto contexto;
        public ComentariosController()
        {
            contexto = new MiContexto();
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(EvaluarComentarioView nuevoComentario)
        {
            if (nuevoComentario is null)
            {
                throw new ArgumentNullException(nameof(nuevoComentario));
            }

            contexto.Comentarios.Add(nuevoComentario);
            contexto.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
