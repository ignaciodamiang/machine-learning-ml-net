using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicationMachineLearning.Service.data
{
    public class SpamPrediction
    {
        [ColumnName("PredictedLabel")]
        public string EsSpam { get; set; }
    }
}
