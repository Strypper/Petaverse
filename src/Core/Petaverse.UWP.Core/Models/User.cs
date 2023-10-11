using System.Collections.ObjectModel;

namespace Petaverse.UWP.Core;

public partial class User : BaseModel<string>
{
    [ObservableProperty]
    string guid;

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
    ObservableCollection<Animal> pets;
}