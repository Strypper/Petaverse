using System.Collections.ObjectModel;

namespace Petaverse.UWP.Core;

public partial class Breed : BaseModel<string>
{
    [ObservableProperty]
    int speciesId;
    [ObservableProperty]
    string breedName;
    [ObservableProperty]
    string breedDescription;
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
    string color;
    [ObservableProperty]
    Species species;

    [ObservableProperty]
    ObservableCollection<Animal> animals;

    //[ObservableProperty]
    //public Coat coat;
}
