
namespace Petaverse.BlackListDetail;

public class BlackListDetailPageService : IBlackListDetailPageService
{

    #region [ Fields ]

    private readonly IBlackListService blackListService;
    #endregion

    #region [ CTor ]
    public BlackListDetailPageService(IBlackListService blackListService)
    {
        this.blackListService = blackListService;
    }
    #endregion

    #region [ Methods ]

    public async Task<BlackListDetailModel> GetBlackListDetailAsync(string id)
    {
        var blackCaseDetail = await blackListService.GetBlackCaseDetailById(id);

        var blackListDetailModel = new BlackListDetailModel
        {
            Title = blackCaseDetail.Title,
            UploadDate = blackCaseDetail.UploadDate,
            Content = blackCaseDetail.Detail,
            Labels = new ObservableCollection<Label>(blackCaseDetail.Labels),
            NumberOfComments = blackCaseDetail.Comments.Count(),
            IsVerified = blackCaseDetail.IsVerified,
        };

        blackListDetailModel.Participants = new ObservableCollection<Participant>(
            blackCaseDetail.Comments.Select(comment =>
                new Participant
                {
                    Name = comment.User.UserName,
                    AvatarUrl = comment.User.ProfilePicUrl,
                    IsAuthor = comment.User.Id == blackCaseDetail.AuthorId
                }
            )
        );

        return blackListDetailModel;
    }

    #endregion
}
