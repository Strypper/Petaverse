using System.Collections.Generic;

namespace Petaverse.UWP.Core;

public partial class FosterCenter : BaseModel<string>
{
    [ObservableProperty]
    string name;

    [ObservableProperty]
    string logo;

    [ObservableProperty]
    bool isUserFollowing;

    [ObservableProperty]
    string address;

    [ObservableProperty]
    double rating;

    [ObservableProperty]
    string description;

    [ObservableProperty]
    IEnumerable<PetaverseMedia> coverImages;

    [ObservableProperty]
    IEnumerable<FosterCenterMember> members;

    [ObservableProperty]
    IEnumerable<Animal> animals;

    [ObservableProperty]
    IEnumerable<FosterCenterTag> tags;
}
