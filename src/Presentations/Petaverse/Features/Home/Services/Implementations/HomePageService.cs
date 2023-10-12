namespace Petaverse;

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


    public async Task<IEnumerable<HomeCarouselItemUserControlModel>> GetCarouselItemsAsync()
    {
        var topEvents = await _homeService.GetTopEventsAsync();
        List<HomeCarouselItemUserControlModel> events = new();
        foreach (var item in topEvents)
        {
            events.Add(new HomeCarouselItemUserControlModel()
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

    public async Task<IEnumerable<TopFosterCenterModel>> GetTopFosterCentersAsync()
    {
        var fosterCenter = await _homeService.GetFosterCentersAsync();
        List<TopFosterCenterModel> topFosterCenters = new();
        foreach (var item in fosterCenter)
        {
            topFosterCenters.Add(new TopFosterCenterModel()
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
    #endregion
}
