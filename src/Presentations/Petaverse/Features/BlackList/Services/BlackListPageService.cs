namespace Petaverse.BlackList;

public class BlackListPageService : IBlackListPageService
{
    #region [ Fields ]

    private readonly IBlackListService blackListService;
    #endregion

    #region [ CTors ]

    public BlackListPageService(IBlackListService blackListService)
    {
        this.blackListService = blackListService;
    }

    #endregion

    #region [ Methods ]

    public Task<IEnumerable<BlackListItemModel>> GetAllAsync()
    {
        var blackCases = blackListService.GetAllBlackCases();
        List<BlackListItemModel> results = new();

        foreach (var blackCase in blackCases.Result)
        {
            List<TagModel> tags = new();
            blackCase.Labels.ForEach(x => tags.Add(new()
            {
                Name = x.Name,
                Icon = x.Icon,
                IsPrimary = blackCase.PrimaryLabelId == x.Id
            }));

            List<ParticipantModel> participants = new();
            blackCase.Comments.ToList().ForEach(x => participants.Add(new()
            {
                Name = x.User.FirstName + x.User.MiddleName + x.User.LastName,
                AvatarUrl = x.User.ProfilePicUrl,
                IsAuthor = blackCase.AuthorId == x.Id
            }));

            results.Add(new()
            {
                Title = blackCase.Title,
                Points = blackCase.Points,
                UploadDate = blackCase.UploadDate,
                IsVerified = blackCase.IsVerified,
                Participants = new(participants),
                Tags = new(tags),
                NoOfComments = blackCase.Comments.Count()
            });
        }
        return Task.FromResult(results.OrderBy(x => x.UploadDate).AsEnumerable());
    }
    #endregion
}
