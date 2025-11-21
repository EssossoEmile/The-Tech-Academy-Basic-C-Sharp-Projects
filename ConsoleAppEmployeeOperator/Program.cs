using System;

namespace ConsoleAppEmployeeOperator
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee emp1 = new Employee(1, "John", "Doe");
            Employee emp2 = new Employee(2, "Jane", "Smith");
            Employee emp3 = new Employee(1, "Mike", "Brown");

            Console.WriteLine($"emp1 == emp2: {emp1 == emp2}"); // false
            Console.WriteLine($"emp1 == emp3: {emp1 == emp3}"); // true
            Console.WriteLine($"emp1 != emp2: {emp1 != emp2}"); // true

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
