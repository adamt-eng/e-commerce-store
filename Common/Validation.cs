using System.Text.RegularExpressions;

namespace E_Commerce_Store.Common;

internal partial class Validation
{
    internal static bool IsValidEmail(string email) => EmailRegex().IsMatch(email);

    [GeneratedRegex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")]
    private static partial Regex EmailRegex();

    internal static bool IsValidPhoneNumber(string phoneNumber) => PhoneNumberRegex().IsMatch(phoneNumber);
        
    [GeneratedRegex(@"^(\+?\d{1,3}[-.\s]?)?(\(?\d{1,4}\)?[-.\s]?)?[\d]{1,4}[-.\s]?[\d]{1,4}[-.\s]?[\d]{1,4}$")]
    private static partial Regex PhoneNumberRegex();

    internal static bool IsValidUrl(string url) => UrlRegex().IsMatch(url);

    [GeneratedRegex(@"^(https?:\/\/)?([a-zA-Z0-9\-]+\.)+[a-zA-Z]{2,}(:\d+)?(\/\S*)?$", RegexOptions.IgnoreCase)]
    private static partial Regex UrlRegex();
}