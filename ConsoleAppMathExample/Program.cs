using System;

namespace ConsoleAppMathExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Instantiate the MathOperations class
            MathOperations mathOps = new MathOperations();

            // Call the method using positional parameters
            mathOps.CalculateAndDisplay(5, 10);

            // Call the method using named parameters
            mathOps.CalculateAndDisplay(firstNumber: 7, secondNumber: 15);

            // Wait for the user to press a key before closing the console
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
