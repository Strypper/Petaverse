using Petaverse.ViewModels;

namespace Petaverse.Home;

public partial class HomePageViewModel : ViewModelBase
{
    #region [ Fields ]

    private DispatcherTimer timer;
    private readonly IHomePageService _homePageService;
    #endregion

    #region [ Properties ]

    [ObservableProperty]
    int firstItemsIndex;

    [ObservableProperty]
    GridViewItem selectedSecondItem;

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
    }
    #endregion

    #region [ Methods ]

    public Task LoadDataAsync()
    {
        return Task.WhenAll(
                LoadFirstItems(),
                LoadSecondItems(),
                LoadThirdItems(),
                LoadFourthItems()
            );
    }

    private async Task LoadFirstItems()
    {
        if (FirstSectionItems is not null)
            return;

        var firstItems = await _homePageService.GetFirstItemsAsync();
        FirstSectionItems = new(firstItems);
    }

    private async Task LoadSecondItems()
    {
        if (SecondSectionItems is not null)
            return;

        var secondItems = await _homePageService.GetSecondItemsAsync();
        SecondSectionItems = new(secondItems);
    }

    private async Task LoadThirdItems()
    {
        if (ThirdSectionItems is not null)
            return;

        var thirdItems = await _homePageService.GetThirdItemsAsync();
        ThirdSectionItems = new(thirdItems);
    }

    private async Task LoadFourthItems()
    {
        if (FourthSectionItems is not null)
            return;

        var fourthItems = await _homePageService.GetFourthItemsAsync();
        FourthSectionItems = new(fourthItems);
    }

    public void AutoUpdateFirstItemsIndex()
    {
        if (timer is not null)
            return;

        timer = new DispatcherTimer();
        timer.Interval = TimeSpan.FromSeconds(5); // adjust the interval as needed
        timer.Tick += (s, e) =>
        {

            if (FirstItemsIndex >= FirstSectionItems.Count - 1)
                FirstItemsIndex = 0;
            else
                FirstItemsIndex++;
        };
        timer.Start();
    }
    #endregion

}
