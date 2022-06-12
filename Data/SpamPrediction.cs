using Microsoft.ML.Data;

namespace AplicacionMachineLearning.Data
{
    public class SpamPrediction
    {

        [ColumnName("PredictedLabel")]
        public string EsSpam { get; set; }
    }
}
