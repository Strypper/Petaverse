namespace Petaverse.UWP.Contracts;

public interface IAuthenticationService
{
    Task<AuthenticationResponse> AuthenticateAsync(LoginModel model);
    Task<AuthenticationResponse> AuthenticateWithPhoneNumberAsync(LoginWithPhoneNumberModel model);
    Task<RegistrationResponse> RegisterPetaverseUserAsync(RegisteringModel model);
}
