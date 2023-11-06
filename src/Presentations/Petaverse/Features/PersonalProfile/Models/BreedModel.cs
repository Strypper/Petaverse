namespace Petaverse.PersonalProfile;

public partial class AnimalBreedModel : BaseModel<string>
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
    double minimumSize;
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
}
