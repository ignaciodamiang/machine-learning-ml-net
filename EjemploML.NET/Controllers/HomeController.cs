using AplicacionMachineLearning.Model;
using AplicationMachineLearning.Service.Interface;
using EF.Data.EF;
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
        private IEvaluarComentarioService _comentarioService;

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

