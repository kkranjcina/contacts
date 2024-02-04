using ContactAPIs.Core.Repositories;
using ContactAPIs.Models;

namespace ContactAPIs.Dal.Repositories
{
    public class ContactsRepository : Repository<Contact, Guid>, IContactsRepository
    {
        public ContactsRepository(ContactsDbContext dbContext) : base(dbContext)
        {
        }
    }
}
