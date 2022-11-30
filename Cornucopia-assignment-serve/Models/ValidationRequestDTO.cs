using System.ComponentModel.DataAnnotations;

namespace CornucopiaApi.Models;

public class ValidationRequestDTO
{
    [Required] public string CountryName { get; set; }
    [Required] public string PhoneNumber { get; set; }
}