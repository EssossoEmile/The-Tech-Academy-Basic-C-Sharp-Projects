using System;
using System.Linq;

namespace CodeFirstStudent
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new SchoolContext())
            {
                // Create a new student
                var student = new Student
                {
                    FirstName = "John",
                    LastName = "Doe",
                    EnrollmentDate = DateTime.Now
                };

                // Add student to database
                db.Students.Add(student);
                db.SaveChanges();

                // Display all students
                var students = db.Students.ToList();
                Console.WriteLine("All Students in database:");
                foreach (var s in students)
                {
                    Console.WriteLine($"{s.StudentId}: {s.FirstName} {s.LastName}, Enrolled: {s.EnrollmentDate}");
                }
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
