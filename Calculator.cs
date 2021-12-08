//
// [Main  Program]
// A calculator application.
//

using System;

namespace Calculator
{

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
                // Note - 'default' isn't used since 'InputInteger' keeps 
                // promting the user until a valid choice is made.
                double number;
                switch(menuChoice)
                {
                    case 0:
                        isRunning = false;
                        break;

                    case 1:
                        number = UserInput.InputDouble("[ + ] Input a number");
                        result = Add(result, number);
                        break;

                    case 2:
                        number = UserInput.InputDouble("[ - ] Input a number");
                        result = Subtract(result, number);
                        break;

                    case 3:
                        number = UserInput.InputDouble("[ * ] Input a number");
                        result = Multiply(result, number);
                        break;

                    case 4:
                        number = UserInput.InputDouble("[ / ] Input a number");
                        if (number == 0.0)
                        {
                            ErrorMessage("\nError: Can't divide with 0!");
                        }
                        else
                        {
                            result = Divide(result, number);
                        }                  
                        break;

                    case 5:
                        result = 0;
                        break;
                }
            }

        }

    }

}