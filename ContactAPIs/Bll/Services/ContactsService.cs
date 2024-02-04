using ContactAPIs.Core.Repositories;
using ContactAPIs.Core.Services;
using ContactAPIs.Dal.Repositories;
using ContactAPIs.Models;

namespace ContactAPIs.Bll.Services
{
    public class ContactsService : IContactsService
    {
        private readonly IContactsRepository _contactsRepository;

        public ContactsService(IContactsRepository contactsRepository)
        {
            _contactsRepository = contactsRepository;
        }

        public async Task<IEnumerable<Contact>> GetAllContacts()
        {
            var contacts = await _contactsRepository.GetAllAsync();
            return contacts;
        }

        public async Task<Contact> GetContact(Guid id)
        {
            var contact = await _contactsRepository.GetByIdAsync(id);
            return contact;
        }

        public async Task<Contact> AddContact(Contact contact)
        {
            await _contactsRepository.AddAsync(contact);
            return contact;
        }

        public async Task<Contact> UpdateContact(Contact contact)
        {
            await _contactsRepository.UpdateAsync(contact);
            return contact;
        }

        public async Task<Contact> DeleteContact(Contact contact)
        {
            await _contactsRepository.DeleteAsync(contact);
            return contact;
        }
    }
}
