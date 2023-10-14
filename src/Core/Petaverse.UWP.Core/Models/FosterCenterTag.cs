namespace Petaverse.UWP.Core;

public partial class FosterCenterTag : BaseModel<string>
{
    [ObservableProperty]
    string tagName;

    [ObservableProperty]
    string tagColorHex;
}
