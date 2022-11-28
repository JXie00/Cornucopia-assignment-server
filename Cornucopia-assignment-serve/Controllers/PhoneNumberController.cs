using System.ComponentModel.DataAnnotations;
using CornucopiaApi.Interfaces;
using CornucopiaApi.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CornucopiaApi.Controllers;

[Route("api/phonenumbers")]
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

    [HttpPost]
    [Route("validate")]
    [Produces("application/json")]
    [SwaggerOperation(Summary = "Validate a phone number with country name",
        Description = "Validate a given phone number with currently supported country ")]
    [SwaggerResponse(200, "Phone number validated successfully", typeof(ValidationResponseDTO))]
    [SwaggerResponse(400, "Bad Request, invalid phone number or country name")]
    [SwaggerResponse(500, "Error validating phone number ")]
    public async Task<IActionResult> ValidatePhoneNumber([FromBody] [Required] ValidationRequestDTO requestDto)
    {
        try
        {
            var result = await _phoneNumberService.ValidatePhoneNumber(requestDto);
            return Ok(result);
        }
        catch (ArgumentNullException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (InvalidDataException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Something went wrong, please try again later");
        }
    }
}