namespace Petaverse.BlackList;

public partial class ParticipantModel : BaseModel<string>
{
    [ObservableProperty]
    string name;
    [ObservableProperty]
    string avatarUrl;
    [ObservableProperty]
    bool isAuthor;
}
