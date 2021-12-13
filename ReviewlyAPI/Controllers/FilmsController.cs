using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReviewlyApp.Data;
using ReviewlyApp.Data.Context;

namespace ReviewlyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmsController : ControllerBase
    {
        private readonly ReviewlyContext _context;

        public FilmsController(ReviewlyContext context)
        {
            _context = context;
        }

        // GET: api/Films
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Films>>> GetFilms()
        {
            return await _context.Films.ToListAsync();
        }

        // GET: api/Films/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Films>> GetFilms(int id)
        {
            var films = await _context.Films.FindAsync(id);

            if (films == null)
            {
                return NotFound();
            }

            return films;
        }

        // PUT: api/Films/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFilms(int id, Films films)
        {
            if (id != films.FilmId)
            {
                return BadRequest();
            }

            _context.Entry(films).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FilmsExists(id))
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

        // POST: api/Films
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Films>> PostFilms(Films films)
        {
            _context.Films.Add(films);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFilms", new { id = films.FilmId }, films);
        }

        // DELETE: api/Films/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFilms(int id)
        {
            var films = await _context.Films.FindAsync(id);
            if (films == null)
            {
                return NotFound();
            }

            _context.Films.Remove(films);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FilmsExists(int id)
        {
            return _context.Films.Any(e => e.FilmId == id);
        }
    }
}
