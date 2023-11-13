namespace Petaverse.Wiki;

public partial class Breed : BaseModel<string>
{
    [ObservableProperty]
    int speciesId;

    [ObservableProperty]
    string name;

    [ObservableProperty]
    string description;

    [ObservableProperty]
    string imageUrl;

    [ObservableProperty]
    double minimunSize;

    [ObservableProperty]
    double maximumSize;

    [ObservableProperty]
    double minimumWeight;

    [ObservableProperty]
    double maximumWeight;

    [ObservableProperty]
    int minimumLifeSpan;

    [ObservableProperty]
    int maximumLifeSpan;

    [ObservableProperty]
    string colors;

    [ObservableProperty]
    Species species;

    [ObservableProperty]
    Coat coat;

    [ObservableProperty]
    Energy energy;

    [ObservableProperty]
    Shedding shedding;

    [ObservableProperty]
    Size size;
}
