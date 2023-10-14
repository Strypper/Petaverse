namespace Petaverse.FosterCenter;

public partial class AnimalProfilePreviewModel : BaseModel<string>
{
    [ObservableProperty]
    string name;

    [ObservableProperty]
    string avatarUrl;
}
