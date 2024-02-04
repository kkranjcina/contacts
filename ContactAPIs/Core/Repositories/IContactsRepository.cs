using ContactAPIs.Models;

namespace ContactAPIs.Core.Repositories
{
    public interface IContactsRepository : IRepository<Contact, Guid>
    {
    }
}
