using Petaverse.BlackListDetail;
using Petaverse.UWP.LogicProvider.Offline;
using System.Collections.ObjectModel;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml.Media.Animation;

namespace Petaverse.BlackList;

public sealed partial class BlackListPage : Page
{

    #region [ Fields ]

    private readonly BlackListPageViewModel viewModel;
    #endregion

    #region [ Properties ]

    BlackListItemModel animatedItem;
    private List<UWP.Core.Label> MockLabels { get; set; }
    #endregion

    #region [ CTor ]

    public BlackListPage()
    {
        this.InitializeComponent();
        //viewModel = Ioc.Default.GetRequiredService<BlackListPageViewModel>();
        CreateFakeLabels();
        BlackList.ItemsSource = new ObservableCollection<BlackListItemModel>(Convert().GetAwaiter().GetResult());
    }
    #endregion

    #region [ Overrides ]

    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);

    }
    #endregion

    #region [ Event Handlers ]

    private async void Page_Loaded(object sender, RoutedEventArgs e)
    {

    }

    private void BlackListItemUserControl_SelectItem(BlackListItemModel item)
    {
        //Frame.Navigate(typeof(BlackListDetailPage), item, new SlideNavigationTransitionInfo() { Effect = SlideNavigationTransitionEffect.FromRight });
    }
    private void GoBack(Microsoft.UI.Xaml.Controls.SwipeItem sender, Microsoft.UI.Xaml.Controls.SwipeItemInvokedEventArgs args)
    {
        Frame.GoBack();
    }

    private void BlackList_ItemClick(object sender, ItemClickEventArgs e)
    {
        if (BlackList.ContainerFromItem(e.ClickedItem) is ListViewItem container)
        {
            animatedItem = container.Content as BlackListItemModel;

            //var animation = BlackList.PrepareConnectedAnimation("ForwardConnectedAnimation", animatedItem, "TopicIcon");

        }

        Frame.Navigate(typeof(BlackListDetailPage), animatedItem, new SuppressNavigationTransitionInfo());

    }
    #endregion

    private async void BlackList_Loaded(object sender, RoutedEventArgs e)
    {
        //if (animatedItem != null)
        //{
        //    BlackList.ScrollIntoView(animatedItem, ScrollIntoViewAlignment.Default);
        //    BlackList.UpdateLayout();

        //    ConnectedAnimation animation = ConnectedAnimationService.GetForCurrentView().GetAnimation("BackConnectedAnimation");
        //    if (animation != null)
        //    {
        //        if (ApiInformation.IsApiContractPresent("Windows.Foundation.UniversalApiContract", 7))
        //        {
        //            animation.Configuration = new DirectConnectedAnimationConfiguration();
        //        }

        //        await BlackList.TryStartConnectedAnimationAsync(animation, animatedItem, "TopicIcon");
        //    }

        //    BlackList.Focus(FocusState.Programmatic);
        //}

    }




    public Task<IEnumerable<BlackCase>> GetAllBlackCases()
    {
        var user1 = new UWP.Core.User { Id = "user1", UserName = "JohnDoe", FirstName = "John", LastName = "Doe", Email = "john@example.com" };
        var user2 = new UWP.Core.User { Id = "user2", UserName = "JaneDoe", FirstName = "Jane", LastName = "Doe", Email = "jane@example.com" };

        var blackCase1 = new BlackCase
        {
            Id = "case1",
            Title = "Harming Animals in Park",
            Users = new List<UWP.Core.User> { user1, user2 },
            Points = 75,
            UploadDate = DateTime.UtcNow.AddDays(-5),
            IsVerified = true,
            Labels = new List<UWP.Core.Label> { MockLabels[0], MockLabels[1] },
            PrimaryLabelId = MockLabels[0].Id,
            AuthorId = user1.Id
        };

        var blackCase2 = new BlackCase
        {
            Id = "case2",
            Title = "Animal Abuse in Residential Area",
            Users = new List<UWP.Core.User> { user2 },
            Points = 90,
            UploadDate = DateTime.UtcNow.AddDays(-10),
            IsVerified = false,
            Labels = new List<UWP.Core.Label> { MockLabels[0], MockLabels[2] },
            PrimaryLabelId = MockLabels[0].Id,
            AuthorId = user2.Id
        };

        return Task.FromResult(new List<BlackCase> { blackCase1, blackCase2 }.AsEnumerable());
    }

    public Task<IEnumerable<BlackListItemModel>> Convert()
    {
        var blackCases = GetAllBlackCases();
        List<BlackListItemModel> results = new();

        foreach (var blackCase in blackCases.Result)
        {
            List<TagModel> tags = new();
            blackCase.Labels.ForEach(x => tags.Add(new()
            {
                Name = x.Name,
                Icon = x.Icon,
                IsPrimary = blackCase.PrimaryLabelId == x.Id
            }));

            List<ParticipantModel> participants = new();
            blackCase.Users.ForEach(x => participants.Add(new()
            {
                Name = x.FirstName + x.MiddleName + x.LastName,
                AvatarUrl = x.ProfilePicUrl,
                IsAuthor = blackCase.AuthorId == x.Id
            }));

            results.Add(new()
            {
                Title = blackCase.Title,
                Points = blackCase.Points,
                UploadDate = blackCase.UploadDate,
                IsVerified = blackCase.IsVerified,
                Participants = new(participants),
                Tags = new(tags)
            });
        }
        return Task.FromResult(results.OrderBy(x => x.UploadDate).AsEnumerable());
    }

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
}
