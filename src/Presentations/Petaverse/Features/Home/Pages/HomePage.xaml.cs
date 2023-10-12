namespace Petaverse;

public sealed partial class HomePage : Page
{
    #region [ Fields ]

    private readonly HomePageViewModel viewModel;
    #endregion

    #region [ CTor ]

    public HomePage()
    {
        this.InitializeComponent();

        viewModel = Ioc.Default.GetRequiredService<HomePageViewModel>();
    }
    #endregion
}
