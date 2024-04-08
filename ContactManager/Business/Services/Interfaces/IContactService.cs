using Business.Dtos;

namespace Business.Services.Interfaces;

public interface IContactService
{
    Task ReadContactsFromCsvAsync(Stream stream);

    Task<List<ContactDto>> GetAllContactsAsync();
}
