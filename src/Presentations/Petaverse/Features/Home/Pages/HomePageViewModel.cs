using Petaverse.ViewModels;

namespace Petaverse.Home;

public partial class HomePageViewModel : ViewModelBase
{
    #region [ Fields ]

    private readonly IHomePageService _homePageService;
    #endregion

    #region [ Properties ]

    [ObservableProperty]
    ObservableCollection<Home_FirstSectionItemModel> firstSectionItems;

    [ObservableProperty]
    ObservableCollection<Home_SecondSectionItemModel> secondSectionItems;

    [ObservableProperty]
    ObservableCollection<Home_ThirdSectionItemModel> thirdSectionItems;

    [ObservableProperty]
    ObservableCollection<Home_FourthSectionItemModel> fourthSectionItems;
    #endregion

    #region [ CTors ]
    public HomePageViewModel()
    {
        _homePageService = Ioc.Default.GetRequiredService<IHomePageService>();

        firstSectionItems = new();
        secondSectionItems = new();
        thirdSectionItems = new();
        fourthSectionItems = new();

        LoadDataAsync();
    }
    #endregion

    #region [ Methods ]

    private async Task LoadDataAsync()
    {
        var firstItems = await _homePageService.GetFirstItemsAsync();
        foreach (var item in firstItems)
        {
            FirstSectionItems.Add(new()
            {
                EventTitle = item.EventTitle,
                EventDominantColor = item.EventDominantColor,
                EventDescription = item.EventDescription,
                EventImage = item.EventImage,
                EventDateTime = item.EventDateTime,
            });
        }

        var secondItems = await _homePageService.GetSecondItemsAsync();
        foreach (var item in secondItems)
        {
            SecondSectionItems.Add(new()
            {
                FosterCenterId = item.FosterCenterId,
                FosterCenterName = item.FosterCenterName,
                FosterCenterLogo = item.FosterCenterLogo,
                FosterCenterAddress = item.FosterCenterAddress,
                FosterCenterRating = item.FosterCenterRating,
                IsUserFollowing = item.IsUserFollowing,
            });
        }

        var thirdItems = await _homePageService.GetThirdItemsAsync();
        foreach (var item in thirdItems)
        {
            ThirdSectionItems.Add(new()
            {
                Title = item.Title,
                Location = item.Location,
                ImageUrl = item.ImageUrl,
                DisplayTime = item.DisplayTime
            });
        }

        var fourthItems = await _homePageService.GetFourthItemsAsync();
        foreach (var item in fourthItems)
        {
            FourthSectionItems.Add(new()
            {
                FirstText = item.FirstText,
                FirstImageUrl = item.FirstImageUrl,
                SecondText = item.SecondText,
                SecondImageUrl = item.SecondImageUrl,
                Activity = item.Activity
            });
        }
    }
    #endregion  

}
