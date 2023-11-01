namespace Petaverse.BlackListDetail;

public sealed partial class BlackListDetailPage : Page
{
    #region [ Fields ]

    private readonly BlackListDetailPageViewModel viewModel;
    #endregion

    #region [ CTor ]

    public BlackListDetailPage()
    {
        this.InitializeComponent();
        viewModel = Ioc.Default.GetRequiredService<BlackListDetailPageViewModel>();
    }
    #endregion

    private async void Page_Loaded(object sender, RoutedEventArgs e)
    {
        await viewModel.LoadBlackListDetail("1");
    }
}
