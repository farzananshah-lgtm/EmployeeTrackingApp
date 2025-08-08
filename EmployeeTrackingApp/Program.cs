using EmployeeTrackingApp.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        using (var context = new AppDbContext()) // Use your updated DbContext
        {
            // Create DB if it doesn't exist
            context.Database.EnsureCreated();

            // Seed sample data if no departments exist
            if (!context.Departments.Any())
            {
                var dept = new Department { Name = "IT" };
                var addr = new Address { Street = "Main St", City = "Karachi", Country = "Pakistan" };

                var emp = new Employee
                {
                    Email = "mustafaahmed@folio3.com",
                    FirstName = "Mustafa",
                    LastName = "Ahmed",
                    DateOfEmployment = new DateTime(2022, 5, 10),
                    Department = dept,
                    Address = addr
                };

                context.Employees.Add(emp);
                context.SaveChanges();
            }

            // Display data
            var employees = context.Employees
                .Include(e => e.Department)
                .Include(e => e.Address)
                .ToList();

            foreach (var emp in employees)
            {
                Console.WriteLine($"{emp.FirstName} {emp.LastName} | {emp.Email} | {emp.Department.Name} | {emp.Address.City}");
            }
        }
    }
}
