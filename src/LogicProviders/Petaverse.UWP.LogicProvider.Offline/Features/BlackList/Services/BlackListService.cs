namespace Petaverse.UWP.LogicProvider.Offline;

public class BlackListService : IBlackListService
{
    #region [ Fields ]

    #endregion

    #region [ CTors ]

    public BlackListService()
    {
        CreateFakeLabels();
    }
    #endregion

    #region [ Properties ]

    private List<Label> MockLabels { get; set; }
    #endregion

    #region [ Methods ]

    public Task<IEnumerable<BlackCase>> GetAllBlackCases()
    {
        var user1 = new User { Id = "user1", UserName = "JohnDoe", FirstName = "John", LastName = "Doe", Email = "john@example.com" };
        var user2 = new User { Id = "user2", UserName = "JaneDoe", FirstName = "Jane", LastName = "Doe", Email = "jane@example.com" };

        var blackCase1 = new BlackCase
        {
            Id = "case1",
            Title = "Harming Animals in Park",
            Points = 75,
            UploadDate = DateTime.UtcNow.AddDays(-5),
            IsVerified = true,
            Labels = new List<Label> { MockLabels[0], MockLabels[1] },
            PrimaryLabelId = MockLabels[0].Id,
            AuthorId = user1.Id
        };

        var blackCase2 = new BlackCase
        {
            Id = "case2",
            Title = "Animal Abuse in Residential Area",
            Points = 90,
            UploadDate = DateTime.UtcNow.AddDays(-10),
            IsVerified = false,
            Labels = new List<Label> { MockLabels[0], MockLabels[2] },
            PrimaryLabelId = MockLabels[0].Id,
            AuthorId = user2.Id
        };

        return Task.FromResult(new List<BlackCase> { blackCase1, blackCase2 }.AsEnumerable());
    }

    public async Task<BlackCaseDetail> GetBlackCaseDetailById(string id)
    {
        throw new NotImplementedException();
    }

    #endregion

    #region [ Private Methods ]

    void CreateFakeLabels()
    {
        MockLabels = new()
        {
            new() { Id = "1", Name = "Bạo hành động vật", Icon = "\U0001F915" },
            new() { Id = "2", Name = "Thái độ tiêu cực", Icon = "\U0001F621" },
            new() { Id = "3", Name = "Spam", Icon = "\U0001F92C" },
            new() { Id = "4", Name = "Tài khoản giả mạo", Icon= "\U0001F978" },
            new() { Id = "5", Name = "Lừa đảo trôm thú cưng", Icon = "\U0001F92C" },
        };
    }
    #endregion
}
