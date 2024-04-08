using Data.Data;
using Data.Repositories;
using Data.Repositories.Iterfaces;

namespace Data.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly DBContext _context;

    public UnitOfWork(DBContext context)
    {
        _context = context;
        Contacts = new ContactRepository(_context);
    }

    public IContactRepository Contacts { get; private set; }

    public int Complete()
    {
        return _context.SaveChanges();
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
        _context.Dispose();
    }
}
