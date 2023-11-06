namespace Petaverse.PersonalProfile;

public partial class PetAvatar : BaseModel<string>
{
    [ObservableProperty]
    string avatarUrl;
}
