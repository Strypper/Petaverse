namespace Petaverse.UWP.Core;

public partial class FosterCenter : BaseModel<string>
{
    [ObservableProperty]
    string name;
    [ObservableProperty]
    string logo;
    [ObservableProperty]
    bool isUserFollowing;
    [ObservableProperty]
    string address;
    [ObservableProperty]
    double rating;
}
