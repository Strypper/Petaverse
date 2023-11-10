using Petaverse.BlackListDetail;
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
    #endregion

    #region [ CTor ]

    public BlackListPage()
    {
        this.InitializeComponent();
        viewModel = Ioc.Default.GetRequiredService<BlackListPageViewModel>();
    }
    #endregion

    #region [ Event Handlers ]

    private async void Page_Loaded(object sender, RoutedEventArgs e)
    {
        await viewModel.LoadDataAsync();
    }

    private void BlackListItemUserControl_SelectItem(BlackListItemModel item)
    {
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
            BlackList.PrepareConnectedAnimation("ForwardConnectedAnimation", animatedItem, "TopicIcon");
        }

        Frame.Navigate(typeof(BlackListDetailPage), animatedItem, new SlideNavigationTransitionInfo() { Effect = SlideNavigationTransitionEffect.FromRight });

    }

    private async void BlackList_Loaded(object sender, RoutedEventArgs e)
    {
        if (animatedItem != null)
        {
            BlackList.ScrollIntoView(animatedItem, ScrollIntoViewAlignment.Default);
            BlackList.UpdateLayout();

            ConnectedAnimation animation = ConnectedAnimationService.GetForCurrentView().GetAnimation("BackConnectedAnimation");
            if (animation != null)
            {
                if (ApiInformation.IsApiContractPresent("Windows.Foundation.UniversalApiContract", 7))
                {
                    animation.Configuration = new DirectConnectedAnimationConfiguration();
                }

                await BlackList.TryStartConnectedAnimationAsync(animation, animatedItem, "TopicIcon");
            }

            BlackList.Focus(FocusState.Programmatic);
        }
    }
    #endregion
}
