
namespace PLTest.Models.ML
{
    public static class MlController
    {
        private static string[] labels = new string[] 
        {
            "cpp",
            "cs",
            "ruby",
            "php",
            "js",
            "vb",
            "python",
            "java",
            "go",
            "ts",
            "kotlin",
            "swift"
        };
        public static Dictionary<string,float> get_prediction_result(string inp) 
        {
            MLModel.ModelInput sampleData = new MLModel.ModelInput()
            {
                Q1 = Single.Parse(inp[0].ToString()),
                Q2 = Single.Parse(inp[1].ToString()),
                Q3 = Single.Parse(inp[2].ToString()),
                Q4 = Single.Parse(inp[3].ToString()),
                Q5 = Single.Parse(inp[4].ToString()),
            };

            // Make a single prediction on the sample data and print results
            var predictionResult = MLModel.Predict(sampleData);
            Dictionary<string, float> result = new Dictionary<string, float>();
            for(int i = 0; i < 12; i++) 
            {
                result.Add(labels[i], predictionResult.Score[i]);
            }
            result.Add("c", 0F); //Данных для языка программирования "C" и "Assembler" просто не оказалось...
            result.Add("asm", 0F); 
            return result;
        }
    }
}
