namespace Petaverse;

public partial class TopFosterCenterModel : BaseModel<string>
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
