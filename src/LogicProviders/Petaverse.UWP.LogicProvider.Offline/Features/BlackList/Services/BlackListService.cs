using Petaverse.UWP.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using Windows.Storage;

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

    private List<Label> Labels;
    #endregion

    #region [ Methods ]

    public Task<IEnumerable<BlackCase>> GetAllBlackCases()
    {
        var faker = new Faker<BlackCase>()
        .RuleFor(b => b.Id, f => f.Random.Guid().ToString())
        .RuleFor(b => b.Title, f => f.Lorem.Sentence())
        .RuleFor(b => b.Users, f => new List<User>()) // You can generate fake users here if needed
        .RuleFor(b => b.Points, f => f.Random.Int(0, 100))
        .RuleFor(b => b.UploadDate, f => f.Date.Past())
        .RuleFor(b => b.AuthorId, f => f.Random.Guid().ToString())
        .RuleFor(b => b.IsVerified, f => f.Random.Bool())
        .RuleFor(b => b.Labels, f => f.PickRandom(this.Labels, f.Random.Int(1, 3)));

        var blackCases = faker.Generate(10);

        foreach (var blackCase in blackCases)
        {
            blackCase.PrimaryLabel = new Faker().PickRandom(blackCase.Labels);
        }

        return Task.FromResult(blackCases.AsEnumerable());
    }

    public async Task<BlackCaseDetail> GetBlackCaseDetailById(string id)
    {
        var bogus = new Faker<BlackCaseDetail>()
            .RuleFor(b => b.Id, f => id)
            .RuleFor(b => b.Title, f => f.Lorem.Sentence())
            .RuleFor(b => b.Detail, f => f.Lorem.Paragraph())
            .RuleFor(b => b.Users, f => f.Make(3, () => new User
            {
                Guid = f.Random.Guid().ToString(),
                UserName = f.Internet.UserName(),
                FirstName = f.Name.FirstName(),
                LastName = f.Name.LastName(),
                Email = f.Internet.Email(),
                PhoneNumber = f.Phone.PhoneNumber(),
                Gender = f.PickRandom<bool?>(true, false),
                DateOfBirth = f.Date.Past(),
                ProfilePicUrl = f.Image.LoremFlickrUrl()
            }))
            .RuleFor(b => b.Points, f => f.Random.Int(0, 100))
            .RuleFor(b => b.UploadDate, f => f.Date.Past())
            .RuleFor(b => b.IsVerified, f => f.Random.Bool())
            .RuleFor(b => b.PrimaryLabel, f => f.PickRandom(Labels)) // Use your provided Labels
            .RuleFor(b => b.Labels, f => f.Make(3, () => f.PickRandom(Labels))); // Use your provided Labels and adjust the count

        var fakeBlackCaseDetail = bogus.Generate();

        // Set the AuthorId property by picking a random user's Guid from the Users list
        var randomUser = fakeBlackCaseDetail.Users[new Random().Next(0, fakeBlackCaseDetail.Users.Count)];
        fakeBlackCaseDetail.AuthorId = randomUser.Guid;

        // Read the content of the text file from the Assets folder
        var file = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/BlackListDetailMarkdownSampleData.txt"));
        var fileContent = await FileIO.ReadTextAsync(file);

        // Set the file content to the Detail property (in lowercase)
        fakeBlackCaseDetail.Detail = fileContent;

        return fakeBlackCaseDetail;
    }

    #endregion

    #region [ Private Methods ]

    void CreateFakeLabels()
    {
        Labels = new()
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
