using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MyWebApi.Model;

namespace MyWebApi.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class NoteBookController : ControllerBase
    {
        public static List<NoteBook> _noteBook = new List<NoteBook>
        {
            new NoteBook  {
            Id = 1,
            Title ="quick notes",
            Content = "This is quick note you can add note in this notes"},

            new NoteBook {
            Id=2,
            Title="sample notes",
            Content="This is sample note you can add note in this notes"
            }
        };

        [HttpGet]
        public ActionResult<NoteBook> GetNotes()
        {
            return Ok(_noteBook);
        }

        [HttpGet("{id}")]
        public ActionResult<NoteBook> GetNoteById(int id)
        {
            var note = _noteBook.FirstOrDefault(c => c.Id == id);
            if (note == null) return NotFound();
            return Ok(note);
        }

        [HttpPost]
        public ActionResult<NoteBook> Addnote([FromBody] NoteBook note)
        {
            _noteBook.Add(note);
            return CreatedAtAction(nameof(Addnote), note);

        }

        [HttpPut("{id}")]
        public ActionResult<NoteBook> UpdateNoteBook([FromBody] NoteBook note)
        {
            return Ok();
            
        }




    }
}