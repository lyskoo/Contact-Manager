using Microsoft.AspNetCore.Http;
using System.Text.RegularExpressions;

namespace Business.Validations;

public static class Validation
{
    public static bool ValidateName(string? name)
    {
        return !string.IsNullOrEmpty(name) && name.Length > 2;
    }

    public static bool ValidateDateOfBirth(DateTime dateOfBirth)
    {
        return dateOfBirth < DateTime.Now;
    }

    public static bool ValidatePhone(string? phone)
    {
        var regex = new Regex(@"^\+380\d{9}$");
        return !string.IsNullOrEmpty(phone) && regex.IsMatch(phone);
    }

    public static bool ValidateSalary(decimal salary)
    {
        return salary >= 0;
    }

    public static bool IsFileNotEmpty(IFormFile file)
    {
        if (file == null || file.Length == 0)
        {
            return false;
        }

        return true;
    }

    public static bool IsFileCsvFormat(IFormFile file)
    {
        if (!file.FileName.EndsWith(".csv", StringComparison.OrdinalIgnoreCase))
        {
            return false;
        }

        return true;
    }
}
