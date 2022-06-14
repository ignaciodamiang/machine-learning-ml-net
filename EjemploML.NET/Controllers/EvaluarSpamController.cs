using AplicacionMachineLearning.Model;
using AplicationMachineLearning.Service.data;
using AplicationMachineLearning.Service.Interface;
using EF.Data.EF;
using Microsoft.AspNetCore.Mvc;
using System;
using static AplicationMachineLearning_Service.MLSpam;

namespace AplicacionMachineLearning.Controllers
{
    public class EvaluarSpamController : Controller
    {
        private readonly IEmailServicio _emailServicio; 


        public EvaluarSpamController(IEmailServicio emailServicio)
        {
            _emailServicio = emailServicio;
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
