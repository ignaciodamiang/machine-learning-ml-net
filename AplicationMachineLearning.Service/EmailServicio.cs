using AplicationMachineLearning.Service.data;
using AplicationMachineLearning.Service.Interface;
using EF.Data.EF;
using EF.Data.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicationMachineLearning.Service
{
    public class EmailServicio : IEmailServicio
    {
        private IEmailRepository _emailRepository;

        public EmailServicio(IEmailRepository emailRepository)
        {
            _emailRepository = emailRepository;
        }

        public void GuardarMensaje(Mensaje mensaje)
        {
            _emailRepository.GuardarMensaje(mensaje);
            _emailRepository.SaveChanges();
        }
    }
}
