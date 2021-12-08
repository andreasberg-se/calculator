//
// [Main  Program]
// A calculator application.
//

using System;

namespace Calculator
{

    // Operators
    enum Operators
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

        // Calculation
        static double Calculation(double currentResult, Operators o)
        {
            double result = currentResult;
            double number;
            switch(o)
            {
                case Operators.Addition:
                    number = UserInput.InputDouble("[ + ] Input a number");
                    result = Add(result, number);
                    break;

                case Operators.Subtraction:
                    number = UserInput.InputDouble("[ - ] Input a number");
                    result = Subtract(result, number);
                    break;

                case Operators.Multiplication:
                    number = UserInput.InputDouble("[ * ] Input a number");
                    result = Multiply(result, number);
                    break;

                case Operators.Division:
                    number = UserInput.InputDouble("[ / ] Input a number");
                    if (number == 0.0)
                    {
                        Console.WriteLine("\nerror: Can't divide with 0!");
                        UserInput.WaitForKey();
                        return result;
                    }
                    result = Divide(result, number);
                    break;

                default:
                    Console.WriteLine("error: Invalid operator!");
                    UserInput.WaitForKey();
                    break;
            }
            return result;
        }

        // Addition of two numbers.
        static double Add(double firstNumber, double secondNumber)
        {
            return firstNumber + secondNumber;
        }

        // Subtraction of two numbers.
        static double Subtract(double firstNumber, double secondNumber)
        {
            return firstNumber - secondNumber;
        }

        // Multiplication of two numbers.
        static double Multiply(double firstNumber, double secondNumber)
        {
            return firstNumber * secondNumber;
        }

        // Division of two numbers.
        static double Divide(double firstNumber, double secondNumber)
        {
            double result = firstNumber;
            if (secondNumber != 0.0)
            {
                result /= secondNumber;
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
                        result = Calculation(result, Operators.Addition);
                        break;

                    case 2:
                        result = Calculation(result, Operators.Subtraction);
                        break;

                    case 3:
                        result = Calculation(result, Operators.Multiplication);
                        break;

                    case 4:
                        result = Calculation(result, Operators.Division);
                        break;

                    case 5:
                        result = 0;
                        break;
                }
            }

        }

    }

}