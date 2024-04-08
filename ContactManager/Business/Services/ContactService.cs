using AutoMapper;
using Business.Dtos;
using Business.Services.Interfaces;
using Business.Validations;
using CsvHelper;
using CsvHelper.Configuration;
using Data.Entities;
using Data.UnitOfWork;
using System.Globalization;

namespace Business.Services;

public class ContactService : IContactService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ContactService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task ReadContactsFromCsvAsync(Stream stream)
    {
        using (var reader = new StreamReader(stream))
        using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
        {
            var records = csv.GetRecords<ContactDto>();
            foreach (var record in records)
            {
                await AddContactAsync(record);
            }
        }
    }

    public async Task AddContactAsync(ContactDto contact)
    {
        if (IsValidContact(contact))
        {
            await _unitOfWork.Contacts.AddAsync(_mapper.Map<Contact>(contact));
            _unitOfWork.Complete();
        }
    }

    public async Task<List<ContactDto>> GetAllContactsAsync()
    {
        return (_mapper.Map<IEnumerable<ContactDto>>(await _unitOfWork.Contacts.GetAllAsync())).ToList();
    }

    public static bool IsValidContact(ContactDto contact)
    {
        return Validation.ValidateName(contact.Name) &&
               Validation.ValidateDateOfBirth(contact.DateOfBirth) &&
               Validation.ValidatePhone(contact.Phone) &&
               Validation.ValidateSalary(contact.Salary);
    }
}
