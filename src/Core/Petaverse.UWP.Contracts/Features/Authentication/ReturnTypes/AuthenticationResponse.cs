namespace Petaverse.UWP.Contracts;

public class AuthenticationResponse : BaseReturnType
{
    public string Id { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string MiddleName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string AvatarUrl { get; set; } = string.Empty;
    public bool IsVerified { get; set; }
    public string PhoneNumber { get; set; } = string.Empty;
}
