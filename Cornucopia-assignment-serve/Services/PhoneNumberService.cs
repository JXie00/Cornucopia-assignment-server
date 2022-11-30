using CornucopiaApi.Interfaces;
using CornucopiaApi.Models;
using CornucopiaApi.Utils;

namespace CornucopiaApi.Services;

public class PhoneNumberService : IPhoneNumberService
{
    public async Task<List<string>> GetAvailableCountries()
    {
        return CountryHelper.GetCountryToCodeMap().Keys.ToList();
    }

    public async Task<ValidationResponseDTO> ValidatePhoneNumber(ValidationRequestDTO req)
    {
        if (req.CountryName == null || req.PhoneNumber == null)
            throw new ArgumentNullException("parameters cannot be null");

        var countryToCodeMap = CountryHelper.GetCountryToCodeMap();

        if (!countryToCodeMap.ContainsKey(req.CountryName))
            throw new InvalidDataException("Given Country Name is not supported yet");

        return PhoneNumberValidator.Validate(req.PhoneNumber, countryToCodeMap[req.CountryName]);
    }
}