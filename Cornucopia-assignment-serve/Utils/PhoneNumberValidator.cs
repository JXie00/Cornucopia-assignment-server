using CornucopiaApi.Models;
using Microsoft.OpenApi.Extensions;
using PhoneNumbers;

namespace CornucopiaApi.Utils;

public static class PhoneNumberValidator
{
    public static ValidationResponseDTO Validate(string phoneNumber, string countryCode)
    {
        var phoneUtil = PhoneNumberUtil.GetInstance();
        var number = phoneUtil.Parse(phoneNumber, countryCode);

        var isValid = phoneUtil.IsValidNumber(number);
        var isPossibleNumber = phoneUtil.IsPossibleNumber(number);
        var phoneNumberType = phoneUtil.GetNumberType(number);
        var internationalFormat = phoneUtil.Format(number, PhoneNumberFormat.INTERNATIONAL);

        return new ValidationResponseDTO(isValid, isPossibleNumber, phoneNumberType.GetDisplayName(),
            internationalFormat);
    }
}