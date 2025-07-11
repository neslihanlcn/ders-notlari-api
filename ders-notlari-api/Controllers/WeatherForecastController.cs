using Microsoft.AspNetCore.Mvc;
using ders_notlari_api.Models;

namespace ders_notlari_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotesController : ControllerBase
    {
        private static List<Note> notes = new();

        [HttpGet]
        public ActionResult<IEnumerable<Note>> GetAll()
        {
            return Ok(notes);
        }

        [HttpGet("{id}")]
        public ActionResult<Note> Get(int id)
        {
            var note = notes.FirstOrDefault(n => n.Id == id);
            if (note == null) return NotFound();
            return Ok(note);
        }

        [HttpPost]
        public ActionResult<Note> Create(Note note)
        {
            note.Id = notes.Count + 1;
            note.CreatedAt = DateTime.UtcNow;
            note.UpdatedAt = DateTime.UtcNow;
            notes.Add(note);
            return CreatedAtAction(nameof(Get), new { id = note.Id }, note);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Note updatedNote)
        {
            var note = notes.FirstOrDefault(n => n.Id == id);
            if (note == null) return NotFound();

            note.Subject = updatedNote.Subject;
            note.Description = updatedNote.Description;
            note.FilePath = updatedNote.FilePath;
            note.UpdatedAt = DateTime.UtcNow;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var note = notes.FirstOrDefault(n => n.Id == id);
            if (note == null) return NotFound();

            notes.Remove(note);
            return NoContent();
        }
    }
}
