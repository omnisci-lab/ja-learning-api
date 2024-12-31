
using System.Text.RegularExpressions;
using System.Text;
using Japanese.Core.Hashing;

namespace Japanese.Core.ExtensionMethods;

public static class StringExtensions
{
    public static string GetSlug(this string input)
    {
        Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
        string url = input.Normalize(NormalizationForm.FormD).Trim().ToLower();

        url = regex.Replace(url, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D').Replace(",", "-").Replace(".", "-")
                    .Replace("!", "").Replace("(", "").Replace(")", "").Replace(";", "-").Replace("/", "-")
                    .Replace("%", "").Replace("&", "").Replace("?", "").Replace('"', '-').Replace(' ', '-');
        return url;
    }

    public static string? SubString(this string input, string endString)
    {
        if (input == null)
            return null;

        if (endString == null)
            return null;

        int index = input.IndexOf(endString);

        return input.Substring(0, input.Length - (input.Length - 1 - index));
    }

    public static string? SubString(this string input, string startString, string endString)
    {
        if (input == null)
            return null;

        if (endString == null)
            return null;

        int index = input.IndexOf(endString);

        return input.Substring(0, input.Length - (input.Length - 1 - index));
    }

    public static string? RemoveHtmlTag(this string input)
    {
        return Regex.Replace(input, "<.*?>", String.Empty);
    }

    public static string MD5(this string input) => HashFunctionHelper.ComputeMD5(input);
    public static string SHA256(this string input) => HashFunctionHelper.ComputeSHA256(input);
    public static string SHA384(this string input) => HashFunctionHelper.ComputeSHA384(input);
    public static string SHA512(this string input) => HashFunctionHelper.ComputeSHA512(input);
}