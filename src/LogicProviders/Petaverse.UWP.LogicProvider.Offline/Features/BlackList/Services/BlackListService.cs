using System.Text;
using Windows.Storage;
using Windows.Storage.Streams;

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

#if DEBUG
    public Task<IEnumerable<BlackCase>> GetAllBlackCases()
    {
        var userFaker = new Faker<User>()
                .RuleFor(u => u.Id, f => f.Random.Guid().ToString())
                .RuleFor(u => u.UserName, f => f.Internet.UserName())
                .RuleFor(u => u.FirstName, f => f.Name.FirstName())
                .RuleFor(u => u.MiddleName, f => f.Name.LastName())
                .RuleFor(u => u.LastName, f => f.Name.LastName())
                .RuleFor(u => u.Email, f => f.Internet.Email())
                .RuleFor(u => u.PhoneNumber, f => f.Phone.PhoneNumber())
                .RuleFor(u => u.Gender, f => f.PickRandom<bool>(true, false))
                .RuleFor(u => u.DateOfBirth, f => f.Date.Past())
                .RuleFor(u => u.ProfilePicUrl, f => f.Internet.Avatar());

        var userFakerList = userFaker.Generate(new Random().Next(1, 20));

        var commentList = new List<BlackListDetailComment>();
        foreach (var user in userFakerList)
        {
            commentList.Add(new()
            {
                User = user,
                CommentDate = new Faker().Date.Past(),
                Detail = new Faker().Lorem.Paragraph()

            });
        }


        var faker = new Faker<BlackCase>()
        .RuleFor(b => b.Id, f => f.Random.Guid().ToString())
        .RuleFor(b => b.Title, f => f.Lorem.Sentence())
        .RuleFor(b => b.Comments, f => commentList)
        .RuleFor(b => b.Points, f => f.Random.Int(0, 100))
        .RuleFor(b => b.UploadDate, f => f.Date.Past())
        .RuleFor(b => b.IsVerified, f => f.Random.Bool())
        .RuleFor(b => b.Labels, f =>
        {
            int numberOfLabels = f.Random.Int(1, 3);

            List<Label> randomLabels = f.PickRandom(MockLabels, numberOfLabels).ToList();

            return randomLabels;
        });
        var blackCases = faker.Generate(25);

        foreach (var blackCase in blackCases)
        {
            blackCase.PrimaryLabelId = new Faker().PickRandom(blackCase.Labels).Id;
            blackCase.AuthorId = new Faker().PickRandom(blackCase.Comments).Id;
        }

        return Task.FromResult(blackCases.AsEnumerable());
    }
#else
    public Task<IEnumerable<BlackCase>> GetAllBlackCases()
    {
        var user1 = new User { Id = "user1", UserName = "JohnDoe", FirstName = "John", LastName = "Doe", Email = "john@example.com" };
        var user2 = new User { Id = "user2", UserName = "JaneDoe", FirstName = "Jane", LastName = "Doe", Email = "jane@example.com" };

        var blackCase1 = new BlackCase
        {
            Id = "case1",
            Title = "Harming Animals in Park",
            Users = new List<User> { user1, user2 },
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
            Users = new List<User> { user2 },
            Points = 90,
            UploadDate = DateTime.UtcNow.AddDays(-10),
            IsVerified = false,
            Labels = new List<Label> { MockLabels[0], MockLabels[2] },
            PrimaryLabelId = MockLabels[0].Id,
            AuthorId = user2.Id
        };

        return Task.FromResult(new List<BlackCase> { blackCase1, blackCase2 }.AsEnumerable());
    }
#endif

    public async Task<BlackCaseDetail> GetBlackCaseDetailById(string id)
    {
        var bogus = new Faker<BlackCaseDetail>()
            .RuleFor(b => b.Id, f => id)
            .RuleFor(b => b.Title, f => f.Lorem.Sentence())
            .RuleFor(b => b.Detail, f => f.Lorem.Paragraph())
            .RuleFor(b => b.Comments, f => f.Make(new Random().Next(1, 20), () => new BlackListDetailComment()
            {
                Id = new Faker().Random.Guid().ToString(),
                BlackListDetailId = id,
                User = new User
                {
                    Id = new Faker().Random.Guid().ToString(),
                    UserName = new Faker().Internet.UserName(),
                    FirstName = new Faker().Name.FirstName(),
                    LastName = new Faker().Name.LastName(),
                    Email = new Faker().Internet.Email(),
                    PhoneNumber = new Faker().Phone.PhoneNumber(),
                    Gender = new Faker().PickRandom<bool?>(true, false),
                    DateOfBirth = new Faker().Date.Past(),
                    ProfilePicUrl = new Faker().Person.Avatar
                },
                Detail = new Faker().Lorem.Paragraph(),
                CommentDate = new Faker().Date.Past()
            }))
            .RuleFor(b => b.Points, f => f.Random.Int(0, 100))
            .RuleFor(b => b.UploadDate, f => f.Date.Past())
            .RuleFor(b => b.IsVerified, f => f.Random.Bool())
            .RuleFor(b => b.PrimaryLabelId, f => f.PickRandom(MockLabels).Id)
            .RuleFor(b => b.Labels, f => f.Make(3, () => f.PickRandom(MockLabels)));

        var fakeBlackCaseDetail = bogus.Generate();

        var randomUser = fakeBlackCaseDetail.Comments.ToList()[new Random().Next(0, fakeBlackCaseDetail.Comments.ToList().Count)];
        fakeBlackCaseDetail.AuthorId = randomUser.Id;

        StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/BlackListDetailMarkdownSampleData.txt"));
        IRandomAccessStreamWithContentType stream = await file.OpenReadAsync();

        using (var reader = new DataReader(stream.GetInputStreamAt(0)))
        {
            uint fileLength = await reader.LoadAsync((uint)stream.Size);
            byte[] fileContent = new byte[fileLength];
            reader.ReadBytes(fileContent);

            // Set the file content to the Detail property (in lowercase)
            fakeBlackCaseDetail.Detail = Encoding.UTF8.GetString(fileContent);
        }

        return fakeBlackCaseDetail;
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
