using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;


namespace AplicacionMachineLearning.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;

        public HomeController(IWebHostEnvironment environment)
        {
            _hostingEnvironment = environment;
        }

        public IActionResult Index()
        {
            return View();
        }
    }





}

