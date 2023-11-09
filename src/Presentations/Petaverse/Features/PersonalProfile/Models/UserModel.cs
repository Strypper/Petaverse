namespace Petaverse.PersonalProfile;

public partial class UserModel : BaseModel<string>
{
    [ObservableProperty]
    string userName;

    [ObservableProperty]
    string firstName;

    [ObservableProperty]
    string middleName;

    [ObservableProperty]
    string lastName;

    [ObservableProperty]
    string fullName;

    [ObservableProperty]
    string email;

    [ObservableProperty]
    string phoneNumber;

    [ObservableProperty]
    bool? gender;

    [ObservableProperty]
    DateTime? dateOfBirth;

    [ObservableProperty]
    string? profilePicUrl;

    [ObservableProperty]
    string? orgPicUrl;

    [ObservableProperty]
    ObservableCollection<AnimalModel> pets = new();
}
