namespace Petaverse;

public partial class Home_SecondSectionItemModel : BaseModel<string>
{
    [ObservableProperty]
    string fosterCenterId;

    [ObservableProperty]
    string fosterCenterName;

    [ObservableProperty]
    string fosterCenterLogo;

    [ObservableProperty]
    bool isUserFollowing;

    [ObservableProperty]
    string fosterCenterAddress;

    [ObservableProperty]
    double fosterCenterRating;
}
