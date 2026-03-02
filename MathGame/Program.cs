using System.Data;

namespace MathGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<List<string>> allTestResults = new List<List<string>>();
            List<string> singleTestResults = new List<string>();

            int correctAnswerCount = 0;
            List<string> additionQuestions = new List<string> { 
                "1 + 1",
                "1 + 2",
                "1 + 3",
                "1 + 4",
                "1 + 5",
                "1 + 6"
            };

            foreach (string question in additionQuestions) {
                object result = new DataTable().Compute(question, null);
                Console.WriteLine(result);
            }
        }
    }
}
