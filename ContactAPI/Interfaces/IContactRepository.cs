using ContactAPI.Models;

namespace ContactAPI.Interfaces
{
    public interface IContactRepository
    {
         Task<Contact> GetContactByIdAsync(int id);
         Task<IEnumerable<Contact>> GetContactsAsync();
         Task<Contact> CreateContactAsync(Contact contact);
         Task UpdateContactAsync(Contact contact);
         Task DeleteContactAsync(int id);

    }
}
