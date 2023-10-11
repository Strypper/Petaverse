using System.Collections.ObjectModel;

namespace Petaverse.UWP.Core;

public partial class Animal : BaseModel<string>
{
    [ObservableProperty]
    string name;
    [ObservableProperty]
    string bio;
    [ObservableProperty]
    string sixDigitCode;
    [ObservableProperty]
    string petColor;
    [ObservableProperty]
    bool gender;
    [ObservableProperty]
    DateTime dateOfBirth;
    [ObservableProperty]
    double age;
    [ObservableProperty]
    Breed breed;

    [ObservableProperty]
    PetaverseMedia petAvatar;

    [ObservableProperty]
    ObservableCollection<PetaverseMedia> petPhotos;
}
