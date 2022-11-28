namespace CornucopiaApi.Models;

public class ValidationResponseDTO
{
    public ValidationResponseDTO(bool isValid, bool isPossible, string phoneType, string internationalFormat)
    {
        IsValid = isValid;
        IsPossible = isPossible;
        PhoneType = phoneType;
        InternationalFormat = internationalFormat;
    }

    public bool IsValid { get; set; }
    public bool IsPossible { get; set; }
    public string PhoneType { get; set; }
    public string InternationalFormat { get; set; }
}