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
    public class AttractionDescController : ControllerBase
    {
        private readonly TourismAPIDBContext _context;

        public AttractionDescController(TourismAPIDBContext context)
        {
            _context = context;
        }

        // GET: api/AttractionDesc
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AttractionDesc>>> GetAttractionDescription()
        {
            return await _context.AttractionDescription.ToListAsync();
        }

        // GET: api/AttractionDesc/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AttractionDesc>> GetAttractionDesc(int id)
        {
            var attractionDesc = await _context.AttractionDescription.FindAsync(id);

            if (attractionDesc == null)
            {
                return NotFound();
            }

            return attractionDesc;
        }

        // PUT: api/AttractionDesc/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAttractionDesc(int id, AttractionDesc attractionDesc)
        {
            if (id != attractionDesc.AttractionId)
            {
                return BadRequest();
            }

            _context.Entry(attractionDesc).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AttractionDescExists(id))
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

        // POST: api/AttractionDesc
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AttractionDesc>> PostAttractionDesc(AttractionDesc attractionDesc)
        {
            _context.AttractionDescription.Add(attractionDesc);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAttractionDesc", new { id = attractionDesc.AttractionId }, attractionDesc);
        }

        // DELETE: api/AttractionDesc/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAttractionDesc(int id)
        {
            var attractionDesc = await _context.AttractionDescription.FindAsync(id);
            if (attractionDesc == null)
            {
                return NotFound();
            }

            _context.AttractionDescription.Remove(attractionDesc);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AttractionDescExists(int id)
        {
            return _context.AttractionDescription.Any(e => e.AttractionId == id);
        }
    }
}
