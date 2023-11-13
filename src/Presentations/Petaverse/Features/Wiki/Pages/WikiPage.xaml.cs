namespace Petaverse.Wiki;

public sealed partial class WikiPage : Page
{

    #region [ Fields ]

    private bool isInitialized = false;
    private readonly WikiPageViewModel viewModel;
    #endregion

    public WikiPage()
    {
        this.InitializeComponent();
        viewModel = Ioc.Default.GetRequiredService<WikiPageViewModel>();

    }
    private async void Page_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
    {
        if (isInitialized)
            return;

        await viewModel.LoadDataAsync();
        isInitialized = true;
    }
}
