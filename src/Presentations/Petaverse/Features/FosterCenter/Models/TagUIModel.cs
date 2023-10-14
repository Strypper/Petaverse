namespace Petaverse.FosterCenter;

public partial class TagUIModel : BaseModel<string>
{
    [ObservableProperty]
    string tagName;

    [ObservableProperty]
    string colorHex;
}
