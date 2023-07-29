using System.Text.RegularExpressions;

namespace Japanese.LanguageCore.RegularExpressions;

public class JaRegex
{
    public bool IsHiragana(char input)
    {
        return Regex.IsMatch(input.ToString(), @"\p{IsHiragana}");
    }

    public MatchCollection Matches()
    {
        return null;
        //return Regex.
    }
}
