namespace Petaverse.BlackList;

public partial class TagModel : BaseModel<string>
{
    [ObservableProperty]
    string name;
    [ObservableProperty]
    string icon;
    [ObservableProperty]
    bool isPrimary;
}
