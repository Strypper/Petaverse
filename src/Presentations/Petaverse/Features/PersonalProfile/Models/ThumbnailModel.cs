
namespace Petaverse.PersonalProfile;

public partial class ThumbnailModel : BaseModel<string>
{
    [ObservableProperty]
    string mediaName;

    [ObservableProperty]
    string mediaUrl;

    [ObservableProperty]
    DateTime timeUpload;

    [ObservableProperty]
    MediaType type;

    [ObservableProperty]
    BitmapImage localImage;
}
