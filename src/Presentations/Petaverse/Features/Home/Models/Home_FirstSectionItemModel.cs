namespace Petaverse;

public partial class Home_FirstSectionItemModel : BaseModel<string>
{
    [ObservableProperty]
    string eventTitle;

    [ObservableProperty]
    string eventDescription;

    [ObservableProperty]
    string eventImage;

    [ObservableProperty]
    string eventDominantColor;

    [ObservableProperty]
    DateTime? eventDateTime;
}
