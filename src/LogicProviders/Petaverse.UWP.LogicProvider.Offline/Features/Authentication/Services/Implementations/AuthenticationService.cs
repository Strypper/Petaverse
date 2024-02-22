namespace Petaverse.UWP.LogicProvider.Offline;

public class AuthenticationService : IAuthenticationService
{
    public Task<AuthenticationResponse> AuthenticateAsync(LoginModel model)
    {

        if (model.Password is null)
            return Task.FromResult<AuthenticationResponse>(new()
            {
                IsSuccess = false,
                ReasonFailed = "No password was included"
            });
        else
        {
            var dummyUser = GenerateDummyUser();
            return Task.FromResult<AuthenticationResponse>(new AuthenticationResponse
            {
                IsSuccess = true,
                Id = dummyUser.Id,
                Email = dummyUser.Email,
                UserName = dummyUser.UserName,
                FirstName = dummyUser.FirstName,
                MiddleName = dummyUser.MiddleName,
                LastName = dummyUser.LastName,
                AvatarUrl = dummyUser.AvatarUrl,
                IsVerified = dummyUser.IsVerified,
                PhoneNumber = dummyUser.PhoneNumber
            });
        }
    }

    public Task<AuthenticationResponse> AuthenticateWithPhoneNumberAsync(LoginWithPhoneNumberModel model)
    {
        if (model.Password is null)
        {
            return Task.FromResult<AuthenticationResponse>(new AuthenticationResponse
            {
                IsSuccess = false,
                ReasonFailed = "No password was included"
            });
        }
        else
        {
            var dummyUser = GenerateDummyUser();
            return Task.FromResult<AuthenticationResponse>(new AuthenticationResponse
            {
                IsSuccess = true,
                Id = dummyUser.Id,
                Email = dummyUser.Email,
                UserName = dummyUser.UserName,
                FirstName = dummyUser.FirstName,
                MiddleName = dummyUser.MiddleName,
                LastName = dummyUser.LastName,
                AvatarUrl = dummyUser.AvatarUrl,
                IsVerified = dummyUser.IsVerified,
                PhoneNumber = dummyUser.PhoneNumber
            });
        }
    }

    public Task<RegistrationResponse> RegisterPetaverseUserAsync(RegisteringModel model)
    {
        throw new NotImplementedException();
    }


    private AuthenticationResponse GenerateDummyUser()
    {
        var dummyUser = new AuthenticationResponse
        {
            Id = Guid.NewGuid().ToString(),
            Email = "dummy@example.com",
            UserName = "dummy_user",
            FirstName = "Dummy",
            MiddleName = "Middle",
            LastName = "User",
            AvatarUrl = "https://example.com/avatar.jpg",
            IsVerified = true,
            PhoneNumber = "+1234567890"
        };

        return dummyUser;
    }
}
