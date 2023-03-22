using ContactAPI.Interfaces;
using ContactAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactAPI.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly ContactContext _contactContext;

        public ContactRepository(ContactContext contactContext)
        {
            _contactContext = contactContext;
        }

        public async Task<Contact> CreateContactAsync(Contact contact)
        {
            var createdContact = _contactContext.Contacts.Add(contact);
            await _contactContext.SaveChangesAsync(CancellationToken.None);
            return createdContact.Entity;
        }

        public async Task DeleteContactAsync(int id)
        {
            var contact = await _contactContext.Contacts.FindAsync(id);
            if (contact != null)
            {
                _contactContext.Contacts.Remove(contact);
                await _contactContext.SaveChangesAsync(CancellationToken.None);
            }

        }

        public async Task<Contact> GetContactByIdAsync(int id)
        {

            return await _contactContext.Contacts.FindAsync(id);

        }

        public async Task<IEnumerable<Contact>> GetContactsAsync()
        {
            return await _contactContext.Contacts.ToListAsync();
        }

        public async Task UpdateContactAsync(Contact contact)
        {
            _contactContext.Entry(contact).State = EntityState.Modified;
            await _contactContext.SaveChangesAsync(CancellationToken.None);
        }

    }
}
