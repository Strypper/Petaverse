namespace Petaverse.PersonalProfile;

public partial class AnimalModel : BaseModel<string>
{
    [ObservableProperty]
    string name;
    [ObservableProperty]
    string? bio;
    [ObservableProperty]
    string? sixDigitCode;
    [ObservableProperty]
    string? petColors;
    [ObservableProperty]
    bool? gender;
    [ObservableProperty]
    DateTime? dateOfBirth;
    [ObservableProperty]
    double? age;
    [ObservableProperty]
    AnimalBreedModel? breed;
    [ObservableProperty]
    PetAvatar petAvatar;
    [ObservableProperty]
    ObservableCollection<ThumbnailModel> thumbnails = new();
}
