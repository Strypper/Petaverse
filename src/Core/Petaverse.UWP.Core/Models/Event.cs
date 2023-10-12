namespace Petaverse.UWP.Core;

public partial class Event : BaseModel<string>
{
    [ObservableProperty]
    string title;

    [ObservableProperty]
    string description;

    [ObservableProperty]
    string image;

    [ObservableProperty]
    string dominantColor;

    [ObservableProperty]
    DateTime? dateTime;
}
