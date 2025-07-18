using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ders_notlari_api.Data;
using ders_notlari_api.Models;

namespace ders_notlari_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NoteController : ControllerBase
    {
        private readonly AppDbContext _context;

        public NoteController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Note
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Note>>> GetNotes()
        {
            if (_context.Notes == null)
                return NotFound();

            return await _context.Notes.ToListAsync();
        }

        // GET: api/Note/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Note>> GetNote(int id)
        {
            if (_context.Notes == null)
                return NotFound();

            var note = await _context.Notes.FindAsync(id);
            if (note == null)
                return NotFound();

            return note;
        }

        // POST: api/Note
        [HttpPost]
        public async Task<ActionResult<Note>> PostNote(Note note)
        {
            _context.Notes.Add(note);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetNote), new { id = note.Id }, note);
        }

        // PUT: api/Note/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNote(int id, Note note)
        {
            if (id != note.Id)
                return BadRequest();

            _context.Entry(note).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Notes.Any(e => e.Id == id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE: api/Note/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNote(int id)
        {
            if (_context.Notes == null)
                return NotFound();

            var note = await _context.Notes.FindAsync(id);
            if (note == null)
                return NotFound();

            _context.Notes.Remove(note);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
