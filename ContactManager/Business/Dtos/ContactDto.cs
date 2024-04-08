using CsvHelper.Configuration.Attributes;

namespace Business.Dtos;

public class ContactDto
{
    [Ignore]
    public Guid? Id { get; set; }

    public string? Name { get; set; }

    public DateTime DateOfBirth { get; set; }

    public bool Married { get; set; }

    public string? Phone { get; set; }

    public decimal Salary { get; set; }
}
