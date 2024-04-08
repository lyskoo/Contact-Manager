using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public class Contact
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public string? Name { get; set; }

    public DateTime DateOfBirth { get; set; }

    public bool Married { get; set; }

    [Required]
    public string? Phone { get; set; }

    public decimal Salary { get; set; }
}
