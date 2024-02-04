using ContactAPIs.Models;

namespace ContactAPIs.Core.Services
{
    public interface IContactsService
    {
        Task<IEnumerable<Contact>> GetAllContacts();
        Task<Contact> GetContact(Guid id);
        Task<Contact> AddContact(Contact contact);
        Task<Contact> UpdateContact(Contact contact);
        Task<Contact> DeleteContact(Contact contact);
    }
}
