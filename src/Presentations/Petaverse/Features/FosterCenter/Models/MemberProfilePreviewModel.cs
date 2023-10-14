namespace Petaverse.FosterCenter;

public partial class MemberProfilePreviewModel : BaseModel<string>
{
    [ObservableProperty]
    string userName;

    [ObservableProperty]
    string userAvatarUrl;

    [ObservableProperty]
    string roleName;
}
