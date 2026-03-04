using System.Data;
using System.Diagnostics;

namespace MathGame
{
    internal class Program
    {
        //holds the results for all the tests
        static List<List<string>> allTestResults = new List<List<string>>();

        //holds the results for a single test
        static List<string> singleTestResults = new List<string>();

        //stopwatch to time the test
        static Stopwatch stopwatch = new Stopwatch();

        static void Main(string[] args)
        {
            

            Intro();
        }

        static void Intro()
        {
            Console.WriteLine("\nWelcome to the game! \nI'm going to ask you a few math problems, so let's answer them the best we can.\n\n");
            Console.WriteLine("Choose a math operation: \n+ for Addition\n- for Subtraction\n* for Multiplication\n/ for Division\nrandom for Random\nlist for the list of previous games.\n");
            StartTest(Console.ReadLine());
        }

        static void StartTest(string symbol) {
            string[] allowedSymbols = {"+", "/", "*", "-", "random", "list"};
            Random random = new Random();

            //checking if the right symbol is used
            if (!allowedSymbols.Contains(symbol))
            {
                Console.WriteLine("\nDidn't use the right symbol. Please use correct symbol.");
                Intro();
                return;
            }

            if (symbol == "list")
            {
                ShowList();
                return;
            }

            stopwatch.Start();

            for (int i = 0; i < 6; i++)
            {
                if(symbol == "random")
                {
                    string randomSymbol = allowedSymbols[random.Next(0, allowedSymbols.Length - 2)];
                    Calculate(randomSymbol, random);
                }
                else
                {
                    //putting in random so we don't have to make a Random object each call
                    Calculate(symbol, random);
                }
                    
            }
            
            stopwatch.Stop();

            //converting the stopwatch time to readable seconds.
            TimeSpan span = stopwatch.Elapsed;
            double totalSeconds = span.TotalSeconds;
            Console.WriteLine($"\nGood job! This is how many seconds you took: {totalSeconds}\n");
            stopwatch.Reset();

            Console.WriteLine("You've done it! Click on any button to start over, or close out of the program to leave.\n\n");
            Console.ReadLine();

            //add the whole single list results to the big list
            allTestResults.Add(new List<string>(singleTestResults));
            //clear small list so it has space for the new questions
            singleTestResults.Clear();
            Intro();
        }

        static void Calculate(string symbol, Random random)
        {
            
            int secondNumber = random.Next(1, 101);
            int firstNumber = random.Next(1, 101);

            //making sure the number won't ever become a decimal when dividing
            if (symbol == "/")
            {
                secondNumber = random.Next(1, 101);
                int otherNumber = random.Next(1, 10);
                firstNumber = secondNumber * otherNumber;
            }

            string problem = $"{firstNumber} {symbol} {secondNumber}";

            Console.WriteLine(problem);

            int result = Convert.ToInt32(new DataTable().Compute(problem, null));

            try
            {
                int answer = Convert.ToInt32(Console.ReadLine());

                if (answer == result)
                {
                    Console.WriteLine("\nCorrect! Good job!\n");
                    singleTestResults.Add($"Question: {problem}. Answer correct.");
                    
                }
                else
                {
                    Console.WriteLine($"\nIncorrect. It's actually {result}\n");
                    singleTestResults.Add($"Question: {problem}. Answer incorrect. Wrote {answer} instead of {result}");

                }

            }
            catch
            {
                Console.WriteLine("Please use an actual number. You've got this wrong. We'll start over.");
                singleTestResults.Clear();
                Intro();

            }
        }

        static void ShowList()
        {
            if(allTestResults.Count > 0) {
                for (int i = 0; i < allTestResults.Count; i++)
                {
                    Console.WriteLine($"\nTest {i + 1}\n");
                    for (int j = 0; j < allTestResults[i].Count; j++)
                    {
                        Console.WriteLine(allTestResults[i][j]);
                    }
                }
            }
            else
            {
                Console.WriteLine("\nHmm, it doesn't seem like you have any tests  just yet...\n");
            }

                Intro();
        }
    }
}
