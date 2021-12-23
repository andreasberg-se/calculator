//
// [Main Program]
// A calculator application.
//

using System;
using static System.Console;

namespace Calculator
{

    public class Program
    {
        public const string DivideByZeroMessage = "Can't divide by zero!";

        // Addition of two numbers.
        public static double Add(double x, double y)
        {
            return x + y;
        }

        // Addition of multiple numbers.
        public static double Add(double[] numbers)
        {
            double sum = 0.0;
            for (int i = 0; i < numbers.Length; i++)
            {
                sum += numbers[i];
            }
            return sum;
        }

        // Subtraction of two numbers.
        public static double Subtract(double x, double y)
        {
            return x - y;
        }

        // Subraction of multiple numbers.
        public static double Subtract(double[] numbers)
        {
            if (numbers.Length <= 0)
            {
                return 0.0;
            }
            double sum = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                sum -= numbers[i];
            }
            return sum;
        }

        // Multiplication of two numbers.
        public static double Multiply(double x, double y)
        {
            return x * y;
        }

        // Division of two numbers.
        public static double Divide(double x, double y)
        {
            if (y == 0.0)
            {
                throw new DivideByZeroException(DivideByZeroMessage);
            }
            return x / y;
        }



         // Prompt the user for a 'double' (floating point number).
        public static double InputDouble(string message)
        {
            while(true)
            {
                Console.Write(message + ": ");
                string input = Console.ReadLine();
                double value;
                if (double.TryParse(input, out value)) return value;
            }
        }



        // Main method.
        static void Main(/*string[] args*/)
        {
            // Sum
            double sum = 0.0;

            // Main loop.
            bool isRunning = true;
            while(isRunning)
            {
                // Display the main menu.
                Clear();
                WriteLine("\nCalculator\n" +
                    "[ 1] Addition                           [ 4] Division\n" +
                    "[ 2] Subtraction                        [ 5] Clear\n" +
                    "[ 3] Multiplication\n" +
                    "\n[ 0] Exit\n\n" +
                    $"Sum: {sum}\n");

                // Prompt the user for a selection.
                Write("Select [0-5]: ");
                string menuChoice = ReadLine().Trim();
                Console.WriteLine("");

                // Handle menu choices.
                double number;
                switch(menuChoice)
                {
                    case "0":
                        isRunning = false;
                        break;

                    case "1":
                        number = InputDouble("[ + ] Input a number");
                        sum = Add(sum, number);
                        break;

                    case "2":
                        number = InputDouble("[ - ] Input a number");
                        sum = Subtract(sum, number);
                        break;

                    case "3":
                        number = InputDouble("[ * ] Input a number");
                        sum = Multiply(sum, number);
                        break;

                    case "4":
                        number = InputDouble("[ / ] Input a number");
                        if (number == 0.0)
                        {
                            Write("\nError: " + DivideByZeroMessage);
                            ReadKey();
                        }
                        else
                        {
                            sum = Divide(sum, number);
                        }                  
                        break;

                    case "5":
                        sum = 0.0;
                        break;

                    default:
                        if (menuChoice != "")
                        {
                            Write($"\nError: Invalid choice '{menuChoice}'!");
                            ReadKey();
                        }
                        break;
                }
            }

        }

    }

}