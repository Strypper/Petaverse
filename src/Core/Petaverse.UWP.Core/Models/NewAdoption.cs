namespace Petaverse.UWP.Core;

public partial class NewAdoption : BaseModel<string>
{
    [ObservableProperty]
    string userId;

    [ObservableProperty]
    string petId;

    [ObservableProperty]
    string userName;

    [ObservableProperty]
    string petName;

    [ObservableProperty]
    string adoptionState;

    [ObservableProperty]
    string userImage;

    [ObservableProperty]
    string petImage;
}
