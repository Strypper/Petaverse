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
    //public Task<FosterCenter> GetFosterCenterByIdAsync(string Id)
    //{
    //    var fosterCenter = new FosterCenter
    //    {
    //        Id = Guid.NewGuid().ToString(),
    //        Name = "Fake Foster Center",
    //        Logo = "ms-appx:///Assets/Mocks/FosterCenters/FosterCenterDemo1.jpg",
    //        IsUserFollowing = true, // You can set this based on your requirement
    //        Address = "123 Fake Street, Faketown",
    //        Rating = 4.2, // Set your desired rating
    //        Description = "This is a fake foster center for demonstration purposes.",
    //        CoverImages = new List<PetaverseMedia>
    //    {
    //        new PetaverseMedia
    //        {
    //            Id = Guid.NewGuid().ToString(),
    //            MediaName = "Cover Image 1",
    //            MediaUrl = "ms-appx:///Assets/Mocks/HomePage/TitleDemo1.jpg",
    //            TimeUpload = DateTime.Now.AddDays(-10),
    //            Type = MediaType.Photo,
    //            LocalImage = null
    //        },
    //        // Add more cover images as needed
    //    },
    //        Members = new List<FosterCenterMember>
    //    {
    //        new FosterCenterMember
    //        {
    //            Id = Guid.NewGuid().ToString(),
    //            UserName = "FakeAdmin",
    //            ProfilePicUrl = "ms-appx:///Assets/Logos/Petaverse.png",
    //            RoleName = "Admin"
    //        },
    //        // Add more members as needed
    //    },
    //        Animals = new List<Animal>
    //    {
    //        new Animal
    //        {
    //            Id = Guid.NewGuid().ToString(),
    //            Name = "FakeCat",
    //            PetAvatar = new PetaverseMedia
    //            {
    //                Id = Guid.NewGuid().ToString(),
    //                MediaUrl = "ms-appx:///Assets/Logos/Petaverse.png"
    //            }
    //        },
    //        // Add more animals as needed
    //    },
    //        Tags = new List<FosterCenterTag>
    //    {
    //        new FosterCenterTag
    //        {
    //            Id = Guid.NewGuid().ToString(),
    //            TagName = "FakeTag1",
    //            TagColorHex = "#FF5733"
    //        },
    //        new FosterCenterTag
    //        {
    //            Id = Guid.NewGuid().ToString(),
    //            TagName = "FakeTag2",
    //            TagColorHex = "#0088FF"
    //        },
    //        // Add more tags as needed
    //    },
    //    };

    //    return Task.FromResult(fosterCenter);
    //}
    #endregion
}
