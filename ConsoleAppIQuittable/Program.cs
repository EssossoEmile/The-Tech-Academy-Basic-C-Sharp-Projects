using System;

namespace ConsoleAppIQuittable
{
    class Program
    {
        static void Main(string[] args)
        {
            // Use polymorphism: create an object of type IQuittable
            IQuittable quitter = new Employee("John", "Doe");

            // Call the Quit() method on the IQuittable object
            quitter.Quit();

            // Wait for user input so the console window does not close immediately
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
