
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
        // Retrieve BlackCaseDetail from the BlackListService
        var blackCaseDetail = await blackListService.GetBlackCaseDetailById(id);

        // Map BlackCaseDetail properties to BlackListDetailModel
        var blackListDetailModel = new BlackListDetailModel
        {
            Title = blackCaseDetail.Title,
            UploadDate = blackCaseDetail.UploadDate,
            Content = blackCaseDetail.Detail, // Use lowercase property name
            Labels = new ObservableCollection<Label>(blackCaseDetail.Labels)
        };

        blackListDetailModel.Participants = new ObservableCollection<Participant>(
            blackCaseDetail.Users.Select(user =>
                new Participant
                {
                    // Map user properties to Participant properties
                    Name = user.UserName, // Use uppercase property name
                    AvatarUrl = user.ProfilePicUrl, // Use uppercase property name
                    IsAuthor = user.Id == blackCaseDetail.AuthorId, // Set IsAuthor based on AuthorId
                                                                      // You may need to map more properties based on your actual data structure
                }
            )
        );

        return blackListDetailModel;
    }

    #endregion
}
