using AutoMapper;
using ContactAPI.DTO;
using ContactAPI.Interfaces;
using ContactAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace ContactAPI.Controllers
{
    [Route("api/contacts")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly ILogger<ContactController> _logger;
        private readonly IMapper _mapper;
        public ContactController(IContactService contactService, ILogger<ContactController> logger, IMapper mapper)
        {
            this._contactService = contactService;
            _logger = logger;
            _mapper = mapper;
        }

        // Get All Contacts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contact>>> GetContacts()
        {

            var contacts = await _contactService.GetContactsAsync();
            if (contacts != null)
            {

                _logger.LogInformation("Returned the contacts");
                return Ok(contacts);
            }
            _logger.LogInformation("Failed retuning the contacts");
            return NotFound();
        }

        // Get Contact By Id 
        [HttpGet("{id}")]
        public async Task<ActionResult<Contact>> GetContact(int id)
        {
            var contact = await _contactService.GetContactByIdAsync(id);
            if (contact == null)
            {
                _logger.LogInformation("Couldn't return a contact with id " + id);
                return NotFound();
            }

            return Ok(contact);
        }

        // Create Contact
        [HttpPost]
        public async Task<ActionResult<ContactDto>> CreateContact(ContactDto contactDto)
        {
            var contact = _mapper.Map<Contact>(contactDto);
            await _contactService.CreateContactAsync(contact);
            _logger.LogInformation("Created a contact with id " + contact.Id);
            return CreatedAtAction(nameof(GetContact), new { Id = contact.Id }, contact);
        }

        // Update Contact
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateContact(int id, Contact contact)
        {

            if (id != contact.Id)
            {
                _logger.LogInformation("Couldn't update the contact with id " + id);
                return BadRequest();
            }

            try
            {
                await _contactService.UpdateContactAsync(contact);
            }
            catch (DbUpdateConcurrencyException)
            {
                var contactToBeDeleted = await _contactService.GetContactByIdAsync(id);
                if (contactToBeDeleted == null)
                {
                    return NotFound();
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Error updating contact");
                }
            }
            _logger.LogInformation("Updated the contact with id " + id);
            return Ok();

        }

        // Delete Contact
        [HttpDelete]
        public async Task<IActionResult> DeleteContact(int id)
        {

            var contact = await _contactService.GetContactByIdAsync(id);
            if (contact == null)
            {
                _logger.LogInformation("Couldn't find the contact with id " + id);
                return NotFound();
            }
            await _contactService.DeleteContactAsync(id);
            _logger.LogInformation("Deleted the contact with id " + id);
            return NoContent();
        }
    }
}
