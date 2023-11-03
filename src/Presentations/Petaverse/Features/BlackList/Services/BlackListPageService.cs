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
            blackCase.Users.ForEach(x => participants.Add(new()
            {
                Name = x.FirstName + x.MiddleName + x.LastName,
                AvatarUrl = x.ProfilePicUrl,
                IsAuthor = blackCase.AuthorId == x.Id
            }));

            results.Add(new()
            {
                Title = blackCase.Title,
                Points = blackCase.Points,
                UploadDate = blackCase.UploadDate,
                IsVerified = blackCase.IsVerified,
                Participants = new(participants),
                Tags = new(tags)
            });
        }
        return Task.FromResult(results.OrderBy(x => x.UploadDate).AsEnumerable());
    }
    #endregion
}
