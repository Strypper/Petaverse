namespace Petaverse.UWP.LogicProvider.Offline;

public class AuthenticationService : IAuthenticationService
{
    public Task<AuthenticationResponse> AuthenticateAsync(LoginModel model)
    {
        var faker = new Faker<AuthenticationResponse>()
                        .RuleFor(u => u.Id, f => f.Random.Guid().ToString())
                        .RuleFor(u => u.Email, f => f.Internet.Email())
                        .RuleFor(u => u.UserName, f => f.Internet.UserName())
                        .RuleFor(u => u.FirstName, f => f.Name.FirstName())
                        .RuleFor(u => u.MiddleName, f => f.Name.FirstName())
                        .RuleFor(u => u.LastName, f => f.Name.LastName())
                        .RuleFor(u => u.AvatarUrl, f => f.Internet.Avatar())
                        .RuleFor(u => u.IsVerified, f => f.Random.Bool())
                        .RuleFor(u => u.PhoneNumber, f => f.Phone.PhoneNumber());
        var user = faker.Generate();

        if (model.Password is null)
            return Task.FromResult<AuthenticationResponse>(new()
            {
                IsSuccess = false,
                ReasonFailed = "No password was included"
            });
        else
            return Task.FromResult<AuthenticationResponse>(new()
            {
                IsSuccess = true,
                Id = user.Id,
                Email = user.Email,
                UserName = user.UserName,
                FirstName = user.FirstName,
                MiddleName = user.MiddleName,
                LastName = user.LastName,
                AvatarUrl = user.AvatarUrl,
                IsVerified = user.IsVerified,
                PhoneNumber = user.PhoneNumber
            });
    }

    public Task<AuthenticationResponse> AuthenticateWithPhoneNumberAsync(LoginWithPhoneNumberModel model)
    {
        var faker = new Faker<AuthenticationResponse>()
                .RuleFor(u => u.Id, f => f.Random.Guid().ToString())
                .RuleFor(u => u.Email, f => f.Internet.Email())
                .RuleFor(u => u.UserName, f => f.Internet.UserName())
                .RuleFor(u => u.FirstName, f => f.Name.FirstName())
                .RuleFor(u => u.MiddleName, f => f.Name.FirstName())
                .RuleFor(u => u.LastName, f => f.Name.LastName())
                .RuleFor(u => u.AvatarUrl, f => f.Internet.Avatar())
                .RuleFor(u => u.IsVerified, f => f.Random.Bool())
                .RuleFor(u => u.PhoneNumber, f => f.Phone.PhoneNumber());
        var user = faker.Generate();

        if (model.Password is null)
            return Task.FromResult<AuthenticationResponse>(new()
            {
                IsSuccess = false,
                ReasonFailed = "No password was included"
            });
        else
            return Task.FromResult<AuthenticationResponse>(new()
            {
                IsSuccess = true,
                Id = user.Id,
                Email = user.Email,
                UserName = user.UserName,
                FirstName = user.FirstName,
                MiddleName = user.MiddleName,
                LastName = user.LastName,
                AvatarUrl = user.AvatarUrl,
                IsVerified = user.IsVerified,
                PhoneNumber = user.PhoneNumber
            });
    }

    public Task<RegistrationResponse> RegisterPetaverseUserAsync(RegisteringModel model)
    {
        var faker = new Faker<RegistrationResponse>()
                    .RuleFor(u => u.NewUserCreatedId, f => f.Random.Guid().ToString())
                    .RuleFor(u => u.IsSuccess, f => true) // Always return success
                    .RuleFor(u => u.Note, f => f.Lorem.Sentence())
                    .RuleFor(u => u.ReasonFailed, f => string.Empty) // No failure reason
                    .RuleFor(u => u.Duration, f => f.Date.Timespan());

        var response = faker.Generate();
        return Task.FromResult<RegistrationResponse>(new()
        {
            IsSuccess = response.IsSuccess,
            NewUserCreatedId = response.NewUserCreatedId,
            Note = response.Note,
            ReasonFailed = response.ReasonFailed,
            Duration = response.Duration
        });
    }
}
