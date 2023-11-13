namespace Petaverse.Wiki;

public partial class Species : BaseModel<string>
{
    [ObservableProperty]
    string name;
    [ObservableProperty]
    string icon;
    [ObservableProperty]
    string color;
    [ObservableProperty]
    string description;
    [ObservableProperty]
    string topLovedPetOfTheWeek;

    [ObservableProperty]
    ObservableCollection<Breed> breeds;
}
