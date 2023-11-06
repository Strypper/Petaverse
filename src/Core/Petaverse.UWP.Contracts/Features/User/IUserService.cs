namespace Petaverse.UWP.Contracts;

public interface IUserService
{
    Task<User> GetById(string id, UserGetByIdSetting? setting);
}
