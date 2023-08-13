namespace IdentityCore.Models;

public class UserModel
{
    public string? FamilyName { get; set; }
    public string? MiddleName { get; set; }
    public string? GivenName { get; set; }
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? Locale { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Gender { get; set; }
    public string? Address { get; set; }
    public DateTime BirthDate { get; set; }
}