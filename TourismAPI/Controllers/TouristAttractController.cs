using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TourismAPI.Models;

namespace TourismAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TouristAttractController : ControllerBase
    {
        private readonly TourismAPIDBContext _context;

        public TouristAttractController(TourismAPIDBContext context)
        {
            _context = context;
        }

        // GET: api/TouristAttract
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TouristAttract>>> GetTouristAttractions()
        {
            return await _context.TouristAttractions.ToListAsync();
        }

        // GET: api/TouristAttract/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TouristAttract>> GetTouristAttract(int id)
        {
            var touristAttract = await _context.TouristAttractions.FindAsync(id);

            if (touristAttract == null)
            {
                return NotFound();
            }

            return touristAttract;
        }

        // PUT: api/TouristAttract/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTouristAttract(int id, TouristAttract touristAttract)
        {
            if (id != touristAttract.PlaceId)
            {
                return BadRequest();
            }

            _context.Entry(touristAttract).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TouristAttractExists(id))
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

        // POST: api/TouristAttract
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TouristAttract>> PostTouristAttract(TouristAttract touristAttract)
        {
            _context.TouristAttractions.Add(touristAttract);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTouristAttract", new { id = touristAttract.PlaceId }, touristAttract);
        }

        // DELETE: api/TouristAttract/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTouristAttract(int id)
        {
            var touristAttract = await _context.TouristAttractions.FindAsync(id);
            if (touristAttract == null)
            {
                return NotFound();
            }

            _context.TouristAttractions.Remove(touristAttract);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TouristAttractExists(int id)
        {
            return _context.TouristAttractions.Any(e => e.PlaceId == id);
        }
    }
}
