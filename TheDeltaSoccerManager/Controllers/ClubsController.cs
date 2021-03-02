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
    [Route("api/Clubs")]
    [ApiController]
    public class ClubsController : ControllerBase
    {
        private readonly SoccerManagerContext _context;

        public ClubsController(SoccerManagerContext context)
        {
            _context = context;
        }

        // GET: api/Clubs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Club>>> GetClub()
        {
            return await _context.Club.ToListAsync();
        }
        
        // GET: api/Clubs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Club>> GetClub(int id)
        {
            var club = await _context.Club.FindAsync(id);

            if (club == null)
            {
                return NotFound();
            }

            return club;
        }

        // PUT: api/Clubs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClub(int id, Club club)
        {
            if (id != club.ClubId)
            {
                return BadRequest();
            }

            _context.Entry(club).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClubExists(id))
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

        // POST: api/Clubs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Club>> PostClub(Club club)
        {
            _context.Club.Add(club);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClub", new { id = club.ClubId }, club);
        }

        // DELETE: api/Clubs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Club>> DeleteClub(int id)
        {
            var club = await _context.Club.FindAsync(id);
            if (club == null)
            {
                return NotFound();
            }

            _context.Club.Remove(club);
            await _context.SaveChangesAsync();

            return club;
        }

        public class PresentationAddToCLubResponse
        {
            public bool success { get; set; }

            public string message { get; set; }
        }
        [HttpPost("{id}/{player_id}")]
        public async Task<ActionResult<Club>> AddPlayerToClub(int id,  int player_id)
        {
            Club new_club = _context.Club.Find(id);
            Player player = _context.Players.Find(player_id);
            if (new_club == null || player == null)
            {
                return NotFound();
            }

            if (player.Club.ClubId == new_club.ClubId)
            {
                return Ok(new PresentationAddToCLubResponse()
                {
                    success = false,
                    message = String.Format("Player {0} has already been transferred to {1}", player.Name, new_club.Name)
                });
            }

            player.Club = new_club;
            _context.Entry(player).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok(new PresentationAddToCLubResponse()
            {
                success = true,
                message = String.Format("Player {0} has been transferred to {1}", player.Name, new_club.Name)
            });
        }

        private bool ClubExists(int id)
        {
            return _context.Club.Any(e => e.ClubId == id);
        }
    }
}
