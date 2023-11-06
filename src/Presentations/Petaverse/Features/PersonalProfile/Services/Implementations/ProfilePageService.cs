using WinRTXamlToolkit.Tools;
using Contracts = Petaverse.UWP.Contracts;

namespace Petaverse.PersonalProfile;

public class ProfilePageService : IProfilePageService
{
    #region [ Fields ]

    private readonly IUserService userService;
    #endregion

    #region [ CTors ]

    public ProfilePageService(IUserService userService)
    {
        this.userService = userService;
    }
    #endregion

    #region [ Methods ]

    public async Task<UserModel> GetUserById(string id, GetUserByIdSetting setting)
    {
        Contracts.UserGetByIdSetting contractsSetting = new()
        {
            IsIncludePetInformation = setting.IsIncludePet
        };
        var data = await userService.GetById(id, contractsSetting);
        UserModel userInfo = new()
        {
            FirstName = data.FirstName,
            MiddleName = data.MiddleName,
            LastName = data.LastName,
            Email = data.Email,
            FullName = data.FirstName + data.MiddleName + data.LastName,
            PhoneNumber = data.PhoneNumber,
            Gender = data.Gender,
            DateOfBirth = data.DateOfBirth,
            ProfilePicUrl = data.ProfilePicUrl
        };

        if (setting is null 
            || 
            setting.IsIncludePet is false 
            || 
            !data.Pets.Any())
            return userInfo;


        data.Pets.ForEach(x =>
        {
            AnimalBreedModel? breedInfo = null;
            if (x.Breed is not null)
            {
                breedInfo.Name = x.Breed.Name;
                breedInfo.Description = x.Breed.Description;
                breedInfo.ImageUrl = x.Breed.ImageUrl;
                breedInfo.MinimumSize = x.Breed.MinimumSize;
                breedInfo.MaximumSize = x.Breed.MaximumSize;
                breedInfo.MinimumWeight = x.Breed.MinimumWeight;
                breedInfo.MaximumWeight = x.Breed.MaximumWeight;
                breedInfo.MinimumLifeSpan = x.Breed.MinimumLifeSpan;
                breedInfo.MaximumLifeSpan = x.Breed.MaximumLifeSpan;
                breedInfo.Colors = x.Breed.Colors;
            }

            List<ThumbnailModel> thumbnails = new();
            x.PetPhotos.ForEach(y => thumbnails.Add(new()
            {
                MediaName = y.MediaName,
                MediaUrl = y.MediaUrl,
                TimeUpload = y.TimeUpload,
                Type = MediaTypeUtil.MapCoreToPersonalProfile(y.Type)
            }));

            userInfo.Pets.Add(new()
            {
                Name = x.Name,
                Bio = x.Bio,
                SixDigitCode = x.SixDigitCode,
                PetColors = x.PetColors,
                Gender = x.Gender,
                DateOfBirth = x.DateOfBirth,
                Age = x.Age,
                PetAvatar = new()
                {
                    AvatarUrl = x.PetAvatar.MediaUrl
                },
                Breed = breedInfo,
                Thumbnails = new(thumbnails)
            });
        });
        return userInfo;

    }
    #endregion
}
