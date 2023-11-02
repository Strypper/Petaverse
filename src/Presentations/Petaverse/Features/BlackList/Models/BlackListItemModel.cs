using System;
namespace Petaverse.BlackList;

public partial class BlackListItemModel : BaseModel<string>
{
    [ObservableProperty]
    string title;

    [ObservableProperty]
    int points;

    [ObservableProperty]
    DateTime uploadDate;

    [ObservableProperty]
    int noOfComments;

    [ObservableProperty]
    bool isVerified;

    [ObservableProperty]
    ObservableCollection<TagModel> tags;

    [ObservableProperty]
    ObservableCollection<ParticipantModel> participants;
}
