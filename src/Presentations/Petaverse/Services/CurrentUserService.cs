using Microsoft.Toolkit.Uwp.Helpers;
using Windows.Storage;

namespace Petaverse.Services;

public class CurrentUserService : ICurrentUserService
{
    private IUserData                    _userData;
    private ApplicationDataContainer     _localSettings;
    private ApplicationDataStorageHelper _appDataStorageHelper;
    public CurrentUserService(HttpClient httpClient,
                              ToolkitSerializer serializer,
                              ApplicationDataContainer appData)
    {
        _localSettings        = appData;
        _userData             = RestService.For<IUserData>(httpClient);
        _appDataStorageHelper = ApplicationDataStorageHelper.GetCurrent(serializer);
    }

    public async Task<Models.DTOs.User> GetUserFromCloud(string userGuid)
       => await _userData.GetByUserGuid(userGuid);

    public async Task<Models.DTOs.User> GetLocalUserAsync(string userGuid)
    {
        return _appDataStorageHelper.Read<Models.DTOs.User>(userGuid);
    }

    public void RemoveLocalUser(string userGuid)
    {
        _appDataStorageHelper.Clear();
    }

    public Task RemoveLocalUserAsync(string userGuid)
    {
        throw new NotImplementedException();
    }

    public async Task SaveLocalUserAsync(Models.DTOs.User currentUser)
    {
        _appDataStorageHelper.Save(currentUser.Guid, currentUser);
    }

    public string GetLocalUserGuidFromAppSettings()
        => _localSettings.Values["UserGuid"] != null 
                ? _localSettings.Values["UserGuid"].ToString()
                : String.Empty;

    public void WriteLocalUserGuidToAppSettings(string userGuild)
        => _localSettings.Values["UserGuid"] = userGuild;

    public void RemoveAllLocalData()
        => _localSettings.Values.Clear();

    public void SaveUserLoginInfo(string Guid, string userName, string passWord)
    {
        var vault = new Windows.Security.Credentials.PasswordVault();
        vault.Add(new Windows.Security.Credentials.PasswordCredential(
            Guid, userName, passWord));


    }
}
