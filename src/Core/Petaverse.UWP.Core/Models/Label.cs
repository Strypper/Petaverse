namespace Petaverse.UWP.Core;

public partial class Label : BaseModel<string>
{
    [ObservableProperty]
    string name;
    [ObservableProperty]
    string color;
    [ObservableProperty]
    string icon;
}
