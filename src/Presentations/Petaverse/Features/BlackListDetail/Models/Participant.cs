namespace Petaverse.BlackListDetail;

public partial class Participant : BaseModel<string>
{
    [ObservableProperty]
    string name;
    [ObservableProperty]
    string avatarUrl;
    [ObservableProperty]
    bool isAuthor;
}
