namespace Japanese.Core.Encoding;

public class Base64
{
    public string? Encode(string? input)
    {
        if (input is null)
            return null;

        byte[] bytes = System.Text.Encoding.UTF8.GetBytes(input);
        return Convert.ToBase64String(bytes);
    }

    public string? Decode(string? base64)
    {
        if (base64 is null)
            return null;

        byte[] bytes = Convert.FromBase64String(base64);
        return System.Text.Encoding.UTF8.GetString(bytes);
    }
}
