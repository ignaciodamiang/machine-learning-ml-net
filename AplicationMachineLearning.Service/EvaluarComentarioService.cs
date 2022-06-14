using AplicationMachineLearning.Service.Interface;
using AplicationMachineLearning.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AplicationMachineLearning_Service;
using EF.Data.Repository.Interface;
using EF.Data.EF;

namespace AplicationMachineLearning.Service
{
    public class EvaluarComentarioService : IEvaluarComentarioService
    {
        private IEvaluarComentarioRepository _evaluarComentarioRepository;

        public EvaluarComentarioService(IEvaluarComentarioRepository comentarioRepository)
        {
            _evaluarComentarioRepository = comentarioRepository;
        }
        public string EvaluarComentarios(string comentario)
        {
            EvaluarComentario evaluarComentario = new EvaluarComentario();
            //Load sample data
            var sampleData = new MLModel.ModelInput()
            {
                Review_es = comentario,
            };

            //Load model and predict output
            var result = MLModel.Predict(sampleData);
            evaluarComentario.Descripcion = comentario;
            evaluarComentario.Valor = result.Prediction.Equals("positivo") ? true : false;
            evaluarComentario.Porcentaje = 0;

            if (result.Prediction == "positivo")
            {
                _evaluarComentarioRepository.GuardarComentario(evaluarComentario);
                _evaluarComentarioRepository.Savechange();
                return "Ese fue un comentario Positivo! Muchas gracias por comentar";
            }
            else
            {
                _evaluarComentarioRepository.GuardarComentario(evaluarComentario);
                _evaluarComentarioRepository.Savechange();
                return "Ese fue un comentario Negativo... lo sentimos!";
            }
        }

        public List<EvaluarComentario> ObtenerListaDeComentarios()
        {
            return  _evaluarComentarioRepository.ObtenerListaDeComentarios();
        }
    }
}
