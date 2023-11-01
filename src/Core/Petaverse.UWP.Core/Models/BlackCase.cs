using System.Collections.Generic;

namespace Petaverse.UWP.Core;

public partial class BlackCase : BaseModel<string>
{
    [ObservableProperty]
    string title;

    [ObservableProperty]
    List<User> users;

    [ObservableProperty]
    int points;

    [ObservableProperty]
    DateTime uploadDate;

    [ObservableProperty]
    string authorId;

    [ObservableProperty]
    bool isVerified;

    [ObservableProperty]
    Label primaryLabel;

    [ObservableProperty]
    List<Label> labels;
}
