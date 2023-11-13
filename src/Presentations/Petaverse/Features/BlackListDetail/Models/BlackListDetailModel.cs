namespace Petaverse.BlackListDetail;

public partial class BlackListDetailModel : BaseModel<string>
{
    [ObservableProperty]
    string title;

    [ObservableProperty]
    ObservableCollection<Participant> participants;

    [ObservableProperty]
    DateTime uploadDate;

    [ObservableProperty]
    string content;

    [ObservableProperty]
    ObservableCollection<Label> labels;

    [ObservableProperty]
    bool isVerified;

    [ObservableProperty]
    int numberOfComments;
}
