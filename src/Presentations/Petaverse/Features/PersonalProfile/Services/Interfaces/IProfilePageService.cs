
namespace Petaverse.PersonalProfile;

public interface IProfilePageService
{
    Task<UserModel> GetUserById(string id, GetUserByIdSetting setting);
}
