using ContactAPI.Interfaces;
using ContactAPI.Models;

namespace ContactAPI.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;

        public ContactService(IContactRepository contactRepository)
        {
            this._contactRepository = contactRepository;
        }
        public async Task<Contact> CreateContactAsync(Contact contact)
        {
            return await _contactRepository.CreateContactAsync(contact);
        }

        public async Task DeleteContactAsync(int id)
        {
          await _contactRepository.DeleteContactAsync(id);
        }

        public async Task<Contact> GetContactByIdAsync(int id)
        {
            return await _contactRepository.GetContactByIdAsync(id);
        }

        public async Task<IEnumerable<Contact>> GetContactsAsync()
        {
            return await _contactRepository.GetContactsAsync();
        }

        public async Task UpdateContactAsync(Contact contact)
        {
            await _contactRepository.UpdateContactAsync(contact);
        }
    }
}
