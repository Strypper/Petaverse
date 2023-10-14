namespace Petaverse.Home;

public partial class Home_FourthSectionItemModel : BaseModel<string>
{
    [ObservableProperty]
    string firstImageUrl;

    [ObservableProperty]
    string firstText;

    [ObservableProperty]
    string secondImageUrl;

    [ObservableProperty]
    string secondText;

    [ObservableProperty]
    string activity;
}
