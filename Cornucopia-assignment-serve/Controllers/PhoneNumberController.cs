using CornucopiaApi.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CornucopiaApi.Controllers;

[Route("api/phones")]
[ApiController]
public class PhoneNumberController : ControllerBase
{
    private readonly IPhoneNumberService _phoneNumberService;

    public PhoneNumberController(IPhoneNumberService phoneNumberService)
    {
        _phoneNumberService = phoneNumberService;
    }

    [HttpGet]
    [Route("availableCountries")]
    [Produces("application/json")]
    [SwaggerOperation(Summary = "Get All available Countries",
        Description = "Returns list of available countries")]
    [SwaggerResponse(200, "List of available countries returned successfully", typeof(List<string>))]
    [SwaggerResponse(500, "Error retrieving countries ")]
    public async Task<IActionResult> GetAvailableCountries()
    {
        try
        {
            var result = await _phoneNumberService.GetAvailableCountries();
            return Ok(result);
        }
        catch (Exception e)
        {
            // ideally we would log the exception here
            Console.WriteLine(e.Message);
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Something went wrong, please try again later");
        }
    }
}