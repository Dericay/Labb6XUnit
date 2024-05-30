using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Labb6XUnit
{
    public class Calculator
    {
        public double Add(double a, double b)
        {
            return a + b;
        }

        public double Subtract(double a, double b)
        {
            return a - b;
        }

        public double Divide(double a, double b)
        {
            if (b == 0)
            {
                throw new ArgumentException("Cannot divide by zero.");
            }
            return a / b;
        }

        public double Multiply(double a, double b)
        {
            return a * b;
        }

        public List<string> History { get; } = new List<string>();

        public void SaveHistory(string function, double a, double b, double result)
        {
            string item = $"{function}: {a} and {b} = {result}";
            History.Add(item);
        }

        public void ShowCalcHistory()
        {
            Console.WriteLine("Calculation history:");
            foreach (var item in History)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
            Console.Clear();
        }

        public static double GetUserInput(string message)
        {
            Console.WriteLine(message);
            return Convert.ToDouble(Console.ReadLine());
        }

        public void RunCalculator()
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine("1.Addition\n2.Subtraction\n3.Division\n4.Multiplication\n5.Calculation History\n6.Quit");

                string userChoice = Console.ReadLine();
                switch (userChoice)
                {
                    case "1":
                        PerformOperation("Addition", Add);
                        break;
                    case "2":
                        PerformOperation("Subtraction", Subtract);
                        break;
                    case "3":
                        PerformOperation("Division", Divide);
                        break;
                    case "4":
                        PerformOperation("Multiplication", Multiply);
                        break;
                    case "5":
                        ShowCalcHistory();
                        break;
                    case "6":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Choice.");
                        break;
                }
            }
        }

        private void PerformOperation(string operationName, Func<double, double, double> operation)
        {
            double a = GetUserInput("Enter the first number:");
            double b = GetUserInput("Enter the second number:");
            try
            {
                double result = operation(a, b);
                Console.WriteLine($"Result of {operationName}: {result}");
                SaveHistory(operationName, a, b, result);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
