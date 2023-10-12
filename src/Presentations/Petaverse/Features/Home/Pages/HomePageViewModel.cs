using Petaverse.ViewModels;

namespace Petaverse;

public partial class HomePageViewModel : ViewModelBase
{
    #region [ Fields ]

    private readonly IHomePageService _homePageService;
    #endregion

    #region [ Properties ]

    [ObservableProperty]
    ObservableCollection<HomeCarouselItemUserControlModel> events;

    [ObservableProperty]
    ObservableCollection<TopFosterCenterModel> topFosterCenters;
    #endregion

    #region [ CTors ]
    public HomePageViewModel()
    {
        _homePageService = Ioc.Default.GetRequiredService<IHomePageService>();

        events = new ObservableCollection<HomeCarouselItemUserControlModel>();
        topFosterCenters = new ObservableCollection<TopFosterCenterModel>();
        LoadDataAsync();
    }
    #endregion

    #region [ Methods ]

    private async Task LoadDataAsync()
    {
        var topEvents = await _homePageService.GetCarouselItemsAsync();
        foreach (var item in topEvents)
        {
            Events.Add(new HomeCarouselItemUserControlModel()
            {
                EventTitle = item.EventTitle,
                EventDominantColor = item.EventDominantColor,
                EventDescription = item.EventDescription,
                EventImage = item.EventImage,
                EventDateTime = item.EventDateTime,
            });
        }

        var topFosterCenter = await _homePageService.GetTopFosterCentersAsync();
        foreach (var item in topFosterCenter)
        {
            TopFosterCenters.Add(new TopFosterCenterModel()
            {
                FosterCenterId = item.FosterCenterId,
                FosterCenterName = item.FosterCenterName,
                FosterCenterLogo = item.FosterCenterLogo,
                FosterCenterAddress = item.FosterCenterAddress,
                FosterCenterRating = item.FosterCenterRating,
                IsUserFollowing = item.IsUserFollowing,
            });
        }
    }
    #endregion  

}
