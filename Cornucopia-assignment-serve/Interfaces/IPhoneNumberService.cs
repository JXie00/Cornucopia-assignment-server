namespace CornucopiaApi.Interfaces;

public interface IPhoneNumberService
{
    public Task<List<string>> GetAvailableCountries();
}