namespace Petaverse.FosterCenter;

public sealed partial class FosterCenterPage : Page
{

    #region [ Fields ]

    private readonly FosterCenterPageViewModel viewModel;
    #endregion

    #region [ CTor ]

    public FosterCenterPage()
    {
        this.InitializeComponent();

        viewModel = Ioc.Default.GetRequiredService<FosterCenterPageViewModel>();
    }
    #endregion
}
