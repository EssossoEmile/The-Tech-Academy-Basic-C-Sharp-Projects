using System;

namespace ConsoleAppIQuittable
{
    // Define the interface IQuittable
    public interface IQuittable
    {
        void Quit();
    }

    // Employee class implements IQuittable
    public class Employee : IQuittable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Employee(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public void Quit()
        {
            Console.WriteLine($"{FirstName} {LastName} has quit the job.");
        }
    }
}
