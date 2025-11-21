using System;

namespace ConsoleAppMathExample
{
    // Define a class named MathOperations
    public class MathOperations
    {
        // Define a void method named CalculateAndDisplay
        // This method takes two integers as parameters
        public void CalculateAndDisplay(int firstNumber, int secondNumber)
        {
            // Perform a math operation on the first integer (for example, multiply by 2)
            int result = firstNumber * 2;

            // Display the result of the math operation
            Console.WriteLine("Result of firstNumber * 2: " + result);

            // Display the second integer as it is
            Console.WriteLine("Second number: " + secondNumber);
        }
    }
}
