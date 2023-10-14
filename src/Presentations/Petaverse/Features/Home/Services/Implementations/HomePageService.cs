using Bogus;

namespace Petaverse.Home;

public class HomePageService : IHomePageService
{
    #region [ Fields ]

    private readonly IHomeService _homeService;
    #endregion

    #region [ CTors ]

    public HomePageService()
    {
        _homeService = Ioc.Default.GetRequiredService<IHomeService>();
    }

    #endregion

    #region [ Methods ]

    public async Task<IEnumerable<Home_FirstSectionItemModel>> GetFirstItemsAsync()
    {
        var topEvents = await _homeService.GetTopEventsAsync();
        List<Home_FirstSectionItemModel> events = new();
        foreach (var item in topEvents)
        {
            events.Add(new Home_FirstSectionItemModel()
            {
                EventTitle = item.Title,
                EventDominantColor = item.DominantColor,
                EventDescription = item.Description,
                EventImage = item.Image,
                EventDateTime = item.DateTime,
            });
        }
        return events;
    }

    public async Task<IEnumerable<Home_SecondSectionItemModel>> GetSecondItemsAsync()
    {
        var fosterCenter = await _homeService.GetFosterCentersAsync();
        List<Home_SecondSectionItemModel> topFosterCenters = new();
        foreach (var item in fosterCenter)
        {
            topFosterCenters.Add(new Home_SecondSectionItemModel()
            {
                FosterCenterId = item.Id,
                FosterCenterName = item.Name,
                FosterCenterLogo = item.Logo,
                FosterCenterAddress = item.Address,
                FosterCenterRating = item.Rating,
                IsUserFollowing = item.IsUserFollowing,
            });
        }
        return topFosterCenters;
    }

    public Task<IEnumerable<Home_ThirdSectionItemModel>> GetThirdItemsAsync()
    {
        return Task.FromResult<IEnumerable<Home_ThirdSectionItemModel>>(new List<Home_ThirdSectionItemModel>()
        {
            new()
            {
                Title = "Cần nuôi",
                Location = "Quận 10",
                ImageUrl = "ms-appx:///Assets/Mocks/AbandonedAnimals/MockAdoptPet1.jpg",
                DisplayTime = new DateTime(2023, 10, 12)
            },
            new()
            {
                Title = "Giữ tạm",
                Location = "Quận 12",
                ImageUrl = "ms-appx:///Assets/Mocks/AbandonedAnimals/MockAdoptPet2.jpg",
                DisplayTime = new DateTime(2023, 10, 02)
            },
            new()
            {
                Title = "Giữ tạm",
                Location = "Quận 3",
                ImageUrl = "ms-appx:///Assets/Mocks/AbandonedAnimals/MockAdoptPet3.jpg",
                DisplayTime = new DateTime(2023, 10, 05)
            },
            new()
            {
                Title = "Cần nuôi",
                Location = "Quận 4",
                ImageUrl = "ms-appx:///Assets/Mocks/AbandonedAnimals/MockAdoptPet4.jpg",
                DisplayTime = new DateTime(2023, 10, 07)
            }
        });
    }

    public Task<IEnumerable<Home_FourthSectionItemModel>> GetFourthItemsAsync()
    {
        List<Home_FourthSectionItemModel> items = new();
        for (int i = 0; i < 30; i++)
        {
            items.Add(new()
            {
                FirstText = new Faker().Person.FirstName,
                FirstImageUrl = new Faker().Person.Avatar,
                SecondText = new Faker().Person.FirstName,
                SecondImageUrl = new Faker().Image.LoremFlickrUrl(480, 480, "cat portrait", false, true),
                Activity = new Faker().Random.Int(1, 2) == 1 ? "Nhận nuôi" : "Nuôi tạm"
            });
        }
        return Task.FromResult<IEnumerable<Home_FourthSectionItemModel>>(items);
    }
    #endregion
}
