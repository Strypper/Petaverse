using Petaverse.UWP.Core;
using System.Linq;

namespace Petaverse.UWP.LogicProvider.Offline;

public class FosterCenterService : IFosterCenterService
{
    #region [ CTor ]

    public FosterCenterService()
    {

    }
    #endregion


    #region [ Methods ]

    public Task<FosterCenter> GetFosterCenterByIdAsync(string Id)
    {
        var faker = new Faker();

        // Generate a fake FosterCenter object
        var fosterCenter = new FosterCenter
        {
            Id = Guid.NewGuid().ToString(),
            Name = faker.Company.CompanyName(),
            Logo = faker.Image.LoremFlickrUrl(500, 300, "Company Logo"),
            IsUserFollowing = faker.Random.Bool(),
            Address = faker.Address.FullAddress(),
            Rating = faker.Random.Double(0, 5),
            Description = faker.Lorem.Paragraph(),
            CoverImages = Enumerable.Range(1, 5).Select(_ => new PetaverseMedia
            {
                Id = Guid.NewGuid().ToString(),
                MediaName = faker.Random.Word(),
                MediaUrl = faker.Image.LoremFlickrUrl(400, 200, "Helping Cats"),
                TimeUpload = faker.Date.Past(),
                Type = MediaType.Photo,
                LocalImage = null // You can generate BitmapImage if needed
            }),
            Members = Enumerable.Range(1, 20).Select(_ => new FosterCenterMember
            {
                Id = Guid.NewGuid().ToString(),
                UserName = faker.Internet.UserName(),
                ProfilePicUrl = new Faker().Person.Avatar,
                RoleName = faker.PickRandom(new[] { "Admin", "Member" })
            }),
            Animals = Enumerable.Range(1, 100).Select(_ => new Animal
            {
                Id = Guid.NewGuid().ToString(),
                Name = faker.Name.FirstName(),
                PetAvatar = new()
                {
                    Id = Guid.NewGuid().ToString(),
                    MediaUrl = faker.Image.LoremFlickrUrl(200, 200, "Tabby Cat")
                }
            }),
            Tags = Enumerable.Range(1, 3).Select(_ => new FosterCenterTag
            {
                Id = Guid.NewGuid().ToString(),
                TagName = faker.Random.Word(),
                TagColorHex = faker.PickRandom(new[] { "#FF5733", "#0088FF", "#44AA55", "#FFAA22", "#9900CC" })
            }),
        };

        return Task.FromResult(fosterCenter);
    }
    #endregion
}
