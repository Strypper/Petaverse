namespace Petaverse;

public partial class Home_ThirdSectionItemModel : BaseModel<string>
{
    [ObservableProperty]
    string title;

    [ObservableProperty]
    string location;

    [ObservableProperty]
    DateTime displayTime;

    [ObservableProperty]
    string description;

    [ObservableProperty]
    int like;

    [ObservableProperty]
    int seen;

    [ObservableProperty]
    string imageUrl;
}
