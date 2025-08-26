using Microsoft.AspNetCore.Mvc;
using MyWebApi.Model;

namespace MyWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private static List<Contact> _contacts = new List<Contact>
        {
            new Contact { Id = 1, Name = "John Doe", Phone = "123-456-7890" },
            new Contact { Id = 2, Name = "Jane Smith", Phone = "098-765-4321" }
        };

        // api/contacts
        [HttpGet]
        public ActionResult<IEnumerable<Contact>> GetContacts()
        {
            return Ok(_contacts);
        }

        // api/contacts/5
        [HttpGet("{id}")]
        public ActionResult<Contact> GetContact(int id)
        {
            var contact = _contacts.FirstOrDefault(c => c.Id == id);
            if (contact == null)
                return NotFound();
            return Ok(contact);
        }

        // api/contacts
        [HttpPost]
        public ActionResult<Contact> AddContact([FromBody] Contact contact)
        {
            contact.Id = _contacts.Count + 1; 
            _contacts.Add(contact);
            return CreatedAtAction(nameof(GetContact), new { id = contact.Id }, contact);
        }

        // api/contacts/5
        [HttpDelete("{id}")]
        public IActionResult DeleteContact(int id)
        {
            var contact = _contacts.FirstOrDefault(c => c.Id == id);
            if (contact == null)
                return NotFound();
            _contacts.Remove(contact);
            return NoContent();
        }
    }
}