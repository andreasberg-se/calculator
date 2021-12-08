//
// [Main  Program]
// A calculator application.
//

using System;

namespace Calculator
{

    // Math Operations
    enum MathOperations
    {
        Addition,
        Subtraction,
        Multiplication,
        Division
    }

    class Program
    {
        
        // Display the main menu.
        static void DisplayMainMenu(double result)
        {
            string[] menuLines = { 
                "\nMain Menu\n",
                "[ 1] Addition                           [ 4] Division",
                "[ 2] Subtraction                        [ 5] Clear",
                "[ 3] Multiplication",
                "\n[ 0] Exit\n",
                $"Result: {result}\n"};

            Console.Clear();
            for (int i = 0; i < menuLines.Length; i++)
            {
                Console.WriteLine(menuLines[i]);
            }
        }

        // Show error message and wait for keypress.
        static void ErrorMessage(string message)
        {
            Console.WriteLine(message);
            UserInput.WaitForKey();
        }

        // Do calculation and return the result.
        static double Calculation(double currentResult, MathOperations mathOperation)
        {
            double result = currentResult;
            double number;
            switch(mathOperation)
            {
                case MathOperations.Addition:
                    number = UserInput.InputDouble("[ + ] Input a number");
                    result = Add(result, number);
                    break;

                case MathOperations.Subtraction:
                    number = UserInput.InputDouble("[ - ] Input a number");
                    result = Subtract(result, number);
                    break;

                case MathOperations.Multiplication:
                    number = UserInput.InputDouble("[ * ] Input a number");
                    result = Multiply(result, number);
                    break;

                case MathOperations.Division:
                    number = UserInput.InputDouble("[ / ] Input a number");
                    if (number == 0.0)
                    {
                        ErrorMessage("\nError: Can't divide with 0!");
                        return result;
                    }
                    result = Divide(result, number);
                    break;

                default:
                    ErrorMessage("Error: Invalid math operation!");
                    break;
            }
            return result;
        }

        // Addition of two numbers.
        static double Add(double x, double y)
        {
            return x + y;
        }

        // Subtraction of two numbers.
        static double Subtract(double x, double y)
        {
            return x - y;
        }

        // Multiplication of two numbers.
        static double Multiply(double x, double y)
        {
            return x * y;
        }

        // Division of two numbers.
        static double Divide(double x, double y)
        {
            double result = x;
            if (y != 0.0)
            {
                result /= y;
            }
            return result;
        }



        // Main method.
        static void Main(/*string[] args*/)
        {
            // Result
            double result = 0;

            // Main loop.
            bool isRunning = true;
            while(isRunning)
            {
                // Display the main menu.
                DisplayMainMenu(result);

                // Prompt the user for a selection.
                int menuChoice = UserInput.InputInteger("Select", 0, 5);
                Console.WriteLine("");

                // Handle menu choices.
                // Note - 'default' isn't used, since 'InputInteger' keeps 
                // promting the user until a valid choice is made.
                switch(menuChoice)
                {
                    case 0:
                        isRunning = false;
                        break;

                    case 1:
                        result = Calculation(result, MathOperations.Addition);
                        break;

                    case 2:
                        result = Calculation(result, MathOperations.Subtraction);
                        break;

                    case 3:
                        result = Calculation(result, MathOperations.Multiplication);
                        break;

                    case 4:
                        result = Calculation(result, MathOperations.Division);
                        break;

                    case 5:
                        result = 0;
                        break;
                }
            }

        }

    }

}