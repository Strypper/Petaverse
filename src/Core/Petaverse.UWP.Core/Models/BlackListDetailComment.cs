namespace Petaverse.UWP.Core;

public partial class BlackListDetailComment : BaseModel<string>
{
    [ObservableProperty]
    string blackListDetailId;

    [ObservableProperty]
    User user;

    [ObservableProperty]
    string detail;

    [ObservableProperty]
    DateTime commentDate;
}
