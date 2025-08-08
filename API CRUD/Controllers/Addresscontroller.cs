using API_CRUD.Model;   
using EmployeeTrackingApp.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_CRUD.Controllers
{
    
        [ApiController]
        [Route("api/[controller]")]
        public class AddressController : ControllerBase
        {
            private readonly AppDbContext _context;

            public AddressController(AppDbContext context)
            {
                _context = context;
            }

            // GET: api/Address
            [HttpGet]
            public async Task<ActionResult<IEnumerable<Addressresponse>>> GetAddresses()
            {
                var addresses = await _context.Addresses
                    .Select(a => new Addressresponse
                    {
                        Id = a.Id,
                        Street = a.Street,
                        City = a.City
                    })
                    .ToListAsync();

                return Ok(addresses);
            }

            // GET: api/Address/5
            [HttpGet("{id}")]
            public async Task<ActionResult<Addressresponse>> GetAddress(int id)
            {
                var address = await _context.Addresses.FindAsync(id);

                if (address == null)
                {
                    return NotFound();
                }

                var response = new Addressresponse
                {
                    Id = address.Id,
                    Street = address.Street,
                    City = address.City
                };

                return Ok(response);
            }

            // POST: api/Address
            [HttpPost]
            public async Task<ActionResult<Addressresponse>> PostAddress(Addressrequest request)
            {
                var address = new Address
                {
                    Street = request.Street,
                    City = request.City
                };

                _context.Addresses.Add(address);
                await _context.SaveChangesAsync();

                var response = new Addressresponse
                {
                    Id = address.Id,
                    Street = address.Street,
                    City = address.City
                };

                return CreatedAtAction(nameof(GetAddress), new { id = response.Id }, response);
            }

            // PUT: api/Address/5
            [HttpPut("{id}")]
            public async Task<IActionResult> PutAddress(int id, Addressrequest request)
            {
                var address = await _context.Addresses.FindAsync(id);
                if (address == null)
                    return NotFound();

                address.Street = request.Street;
                address.City = request.City;

                await _context.SaveChangesAsync();

                return NoContent();
            }

            // DELETE: api/Address/5
            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteAddress(int id)
            {
                var address = await _context.Addresses.FindAsync(id);
                if (address == null)
                    return NotFound();

                _context.Addresses.Remove(address);
                await _context.SaveChangesAsync();

                return NoContent();
            }
        }
    }

