using CornucopiaApi.Models;

namespace CornucopiaApi.Interfaces;

public interface IPhoneNumberService
{
    public Task<List<string>> GetAvailableCountries();
    public Task<ValidationResponseDTO> ValidatePhoneNumber(ValidationRequestDTO request);
}