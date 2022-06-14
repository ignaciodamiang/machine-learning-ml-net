using EF.Data.EF;
using EF.Data.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Data.Repository
{
    public class EmailRepository : IEmailRepository
    {
        private MLdataBaseContext _ctx;

        public EmailRepository(MLdataBaseContext ctx)
        {
            _ctx = ctx;
        }

        public void GuardarMensaje(Mensaje mensaje)
        {
            _ctx.Mensajes.Add(mensaje);
        }

        public void SaveChanges()
        {
            _ctx.SaveChanges();
        }
    }
}
