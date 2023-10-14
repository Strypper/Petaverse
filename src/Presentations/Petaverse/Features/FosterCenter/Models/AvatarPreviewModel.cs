namespace Petaverse.FosterCenter;

public partial class AvatarPreviewModel : BaseModel<string>
{
    [ObservableProperty]
    string title;

    [ObservableProperty]
    string pictureUrl;
}
