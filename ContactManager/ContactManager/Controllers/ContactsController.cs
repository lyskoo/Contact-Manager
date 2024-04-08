using Business.Services.Interfaces;
using Business.Validations;
using Microsoft.AspNetCore.Mvc;

namespace ContactManager.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContactsController : ControllerBase
{
    private IContactService _contactService;

    public ContactsController(IContactService contactService)
    {
        _contactService = contactService;
    }

    [HttpPost("upload")]
    public async Task<IActionResult> UploadCsv(IFormFile file)
    {
        if (!Validation.IsFileNotEmpty(file) || Validation.IsFileCsvFormat(file))
        {
            return BadRequest("Invalid file. Please choose a non-empty CSV file.");
        }

        using (var stream = file.OpenReadStream())
        {
            await _contactService.ReadContactsFromCsvAsync(stream);
            return Ok($"Contacts were successfully uploaded");
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAllContacts()
    {
        return Ok(await _contactService.GetAllContactsAsync());
    }
}
