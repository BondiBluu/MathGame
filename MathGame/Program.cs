using System.Data;
using System.Diagnostics;

namespace MathGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //holds the results for all the tests
            List<List<string>> allTestResults = new List<List<string>>();

            //holds the results for a single test
            List<string> singleTestResults = new List<string>();

            //stopwatch to time the test
            Stopwatch stopwatch = new Stopwatch();

            int correctAnswerCount = 0;

            Intro();
        }

        static void Intro()
        {
            Console.WriteLine("Welcome to the game! \nI'm going to ask you a few math problems, so let's answer them the best we can.\n\n");
            Console.WriteLine("Choose a math operation: \n+ for Addition\n- for Subtraction\n* for Multipication\n/ for Division");
            StartTest(Console.ReadLine());
        }

        static void StartTest(string symbol) {
            HashSet<string> allowedSymbols = new HashSet<string> {"+", "/", "*", "-"};
            Random random = new Random();

            //checking if the right symbol is used
            if (!allowedSymbols.Contains(symbol))
            {
                Console.WriteLine("Didn't use the right symbol. Please use correct symbol.");
                Intro();
            }

            for(int i = 0; i < 6; i++)
            {
                //putting in random so we don't have to make one each call
                Calculate(symbol, random);
            }
        }

        static void Calculate(string symbol, Random random)
        {
            
            int secondNumber = random.Next(1, 101);
            //making sure the number won't ever decome a decimal when dividing
            int otherNumber = random.Next(1, 10);
            int firstNumber = secondNumber * otherNumber;

            string problem = $"{firstNumber} {symbol} {secondNumber}";

            Console.WriteLine(problem);

            int result = Convert.ToInt32(new DataTable().Compute(problem, null));

            try
            {
                int answer = Convert.ToInt32(Console.ReadLine());

                if (answer == result)
                {
                    Console.WriteLine("Correct! Good job!");
                    
                }
                else
                {
                    Console.WriteLine($"Incorrect. It's actually {result}");
                }

            }
            catch
            {
                Console.WriteLine("Please use an actual number.");
            }          
        }
    }
}
