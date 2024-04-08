using Data.Data;
using Data.Entities;
using Data.Repositories.Iterfaces;

namespace Data.Repositories;

public class ContactRepository : Repository<Contact>, IContactRepository
{
    public ContactRepository(DBContext dbContext) : base(dbContext)
    {
    }
}
