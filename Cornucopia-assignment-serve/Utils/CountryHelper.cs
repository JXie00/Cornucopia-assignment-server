namespace CornucopiaApi.Utils;

public static class CountryHelper
{
    public static Dictionary<string, string> GetCountryToCodeMap()
    {
        // use hashmap for it's O(1) lookup time
        var map = new Dictionary<string, string>
        {
            { "Australia", "AU" },
            { "America", "US" },
            { "New Zealand", "NZ" }
        };
        return map;
    }
}