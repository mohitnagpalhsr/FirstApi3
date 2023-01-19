using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FirstApi2.Models;

namespace FirstApi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContainController : ControllerBase
    {
        private readonly FlightBookingDbContext _context;

        public ContainController(FlightBookingDbContext context)
        {
            _context = context;
        }

        // GET: api/Contain
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contain>>> GetContains()
        {
          if (_context.Contains == null)
          {
              return NotFound();
          }
            return await _context.Contains.ToListAsync();
        }

        // GET: api/Contain/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Contain>> GetContain(int id)
        {
          if (_context.Contains == null)
          {
              return NotFound();
          }
            var contain = await _context.Contains.FindAsync(id);

            if (contain == null)
            {
                return NotFound();
            }

            return contain;
        }

        // PUT: api/Contain/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContain(int id, Contain contain)
        {
            if (id != contain.Pid)
            {
                return BadRequest();
            }

            _context.Entry(contain).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContainExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Contain
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Contain>> PostContain(Contain contain)
        {
          if (_context.Contains == null)
          {
              return Problem("Entity set 'FlightBookingDbContext.Contains'  is null.");
          }
            _context.Contains.Add(contain);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ContainExists(contain.Pid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetContain", new { id = contain.Pid }, contain);
        }

        // DELETE: api/Contain/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContain(int id)
        {
            if (_context.Contains == null)
            {
                return NotFound();
            }
            var contain = await _context.Contains.FindAsync(id);
            if (contain == null)
            {
                return NotFound();
            }

            _context.Contains.Remove(contain);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ContainExists(int id)
        {
            return (_context.Contains?.Any(e => e.Pid == id)).GetValueOrDefault();
        }
    }
}
