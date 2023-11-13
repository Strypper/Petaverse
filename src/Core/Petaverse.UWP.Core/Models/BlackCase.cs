using System.Collections.Generic;

namespace Petaverse.UWP.Core;

public partial class BlackCase : BaseModel<string>
{
    [ObservableProperty]
    string title;

    [ObservableProperty]
    int points;

    [ObservableProperty]
    DateTime uploadDate;

    [ObservableProperty]
    string authorId;

    [ObservableProperty]
    bool isVerified;

    [ObservableProperty]
    string primaryLabelId;

    [ObservableProperty]
    List<Label> labels;

    [ObservableProperty]
    IEnumerable<BlackListDetailComment> comments;
}
