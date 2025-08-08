using API_CRUD.Model;
using EmployeeTrackingApp.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_CRUD.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DepartmentController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Departmentresponse>>> GetDepartments()
        {
            var departments = await _context.Departments
                .Select(d => new Departmentresponse
                {
                    Id = d.Id,
                    Name = d.Name
                })
                .ToListAsync();

            return Ok(departments);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Departmentresponse>> GetDepartment(int id)
        {
            var department = await _context.Departments.FindAsync(id);
            if (department == null)
                return NotFound();

            var response = new Departmentresponse
            {
                Id = department.Id,
                Name = department.Name
            };

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Departmentresponse>> PostDepartment(Departmentrequest request)
        {
            var department = new Department
            {
                Name = request.Name
            };

            _context.Departments.Add(department);
            await _context.SaveChangesAsync();

            var response = new Departmentresponse
            {
                Id = department.Id,
                Name = department.Name
            };

            return CreatedAtAction(nameof(GetDepartment), new { id = response.Id }, response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepartment(int id, Departmentrequest request)
        {
            var department = await _context.Departments.FindAsync(id);
            if (department == null)
                return NotFound();

            department.Name = request.Name;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var department = await _context.Departments.FindAsync(id);
            if (department == null)
                return NotFound();

            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();
            return NoContent();


        }
    }
}