using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeeTrackingApp.Entity; // Reference to your EF Core project
using API_CRUD.Model;             // Reference to your DTOs

namespace API_CRUD.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly AppDbContext _context;

        // ✅ Constructor where _context is assigned
        public EmployeeController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] EmployeeRequest request)
        {
            // Check if employee already exists
            var existingEmployee = await _context.Employees
                .FirstOrDefaultAsync(e => e.Email.ToLower() == request.Email.ToLower());

            if (existingEmployee != null)
            {
                return Conflict(new
                {
                    status = 409,
                    message = $"Employee with email '{request.Email}' already exists."
                });
            }

            // Check if department exists
            var department = await _context.Departments
                .FirstOrDefaultAsync(d => d.Name.ToLower() == request.DepartmentName.ToLower());

            if (department == null)
            {
                department = new Department { Name = request.DepartmentName };
                _context.Departments.Add(department);
                await _context.SaveChangesAsync();
            }

            // Check if address exists
            var address = await _context.Addresses
                .FirstOrDefaultAsync(a =>
                    a.Street.ToLower() == request.Street.ToLower() &&
                    a.City.ToLower() == request.City.ToLower() &&
                    a.Country.ToLower() == request.Country.ToLower());

            if (address == null)
            {
                address = new Address
                {
                    Street = request.Street,
                    City = request.City,
                    Country = request.Country
                };
                _context.Addresses.Add(address);
                await _context.SaveChangesAsync();
            }

            // Create the new employee
            var employee = new Employee
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                DateOfEmployment = request.DateOfEmployment,
                AddressId = address.Id,
                DepartmentId = department.Id
            };

            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                status = 200,
                message = "Employee created successfully.",
                employee = new
                {
                    employee.Email,
                    employee.FirstName,
                    employee.LastName,
                    employee.DateOfEmployment,
                    Department = department.Name,
                    Address = $"{address.Street}, {address.City}, {address.Country}"
                }
            });
        }
    }
}
