using Data.Repositories.Iterfaces;

namespace Data.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    IContactRepository Contacts { get; }

    int Complete();
}
