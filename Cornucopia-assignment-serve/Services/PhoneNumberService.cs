using CornucopiaApi.Interfaces;
using CornucopiaApi.Utils;

namespace CornucopiaApi.Services;

public class PhoneNumberService : IPhoneNumberService
{
    public async Task<List<string>> GetAvailableCountries()
    {
        return CountryHelper.GetCountryToCodeMap().Keys.ToList();
    }
}