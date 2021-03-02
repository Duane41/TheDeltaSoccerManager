using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheDeltaSoccerManager.Models;

namespace TheDeltaSoccerManager.Controllers
{
    [Route("api/[Stadiums]")]
    [ApiController]
    public class StadiumsController : ControllerBase
    {
        private readonly SoccerManagerContext _context;

        public StadiumsController(SoccerManagerContext context)
        {
            _context = context;
        }

        // GET: api/Stadium
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Stadium>>> GetStadium()
        {
            return await _context.Stadium.ToListAsync();
        }

        // GET: api/Stadium/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Stadium>> GetStadium(int id)
        {
            var stadium = await _context.Stadium.FindAsync(id);

            if (stadium == null)
            {
                return NotFound();
            }

            return stadium;
        }

        // PUT: api/Stadium/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStadium(int id, Stadium stadium)
        {
            if (id != stadium.StadiumId)
            {
                return BadRequest();
            }

            _context.Entry(stadium).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StadiumExists(id))
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

        // POST: api/Stadium
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Stadium>> PostStadium(Stadium stadium)
        {
            _context.Stadium.Add(stadium);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStadium", new { id = stadium.StadiumId }, stadium);
        }

        // DELETE: api/Stadium/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Stadium>> DeleteStadium(int id)
        {
            var stadium = await _context.Stadium.FindAsync(id);
            if (stadium == null)
            {
                return NotFound();
            }

            _context.Stadium.Remove(stadium);
            await _context.SaveChangesAsync();

            return stadium;
        }

        private bool StadiumExists(int id)
        {
            return _context.Stadium.Any(e => e.StadiumId == id);
        }
    }
}
