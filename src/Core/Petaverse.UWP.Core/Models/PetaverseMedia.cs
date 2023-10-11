using Windows.UI.Xaml.Media.Imaging;

namespace Petaverse.UWP.Core;

public partial class PetaverseMedia : BaseModel<string>
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
