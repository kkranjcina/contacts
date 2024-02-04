using ContactAPIs.Core.Services;
using ContactAPIs.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContactAPIs.Controllers
{
    [ApiController]
    [Route("api/contacts")]
    public class ContactsController : ControllerBase
    {
        private readonly IContactsService _contactsService;

        public ContactsController(IContactsService contactsService)
        {
            _contactsService = contactsService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contact>>> GetAllContacts()
        {
            var contacts = await _contactsService.GetAllContacts();

            if (contacts is not null)
            {
                return Ok(contacts);
            }
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Contact>> GetContact(Guid id)
        {
            var contact = await _contactsService.GetContact(id);

            if (contact is not null)
            {
                return Ok(contact);
            }
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Contact>> CreateContact(Contact request)
        {
            var contact = new Contact(
                request.Id ?? Guid.NewGuid(),
                request.Name,
                request.TelephoneNumber,
                request.Email);

            await _contactsService.AddContact(contact);

            return CreatedAtAction(
                actionName: nameof(GetContact),
                routeValues: new { id = contact.Id },
                value: contact);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Contact>> UpdateContact(Contact contact)
        {
            if (contact is not null)
            {
                var updatedContact = await _contactsService.UpdateContact(contact);
                return Ok(updatedContact);
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Contact>> DeleteContact(Guid id)
        {
            var contact = await _contactsService.GetContact(id);

            if (contact is not null)
            {
                await _contactsService.DeleteContact(contact);
                return Ok();
            }
            return BadRequest();
        }
    }
}
