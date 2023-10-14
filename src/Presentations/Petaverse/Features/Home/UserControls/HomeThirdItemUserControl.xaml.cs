namespace Petaverse.Home;

public sealed partial class HomeThirdItemUserControl : UserControl
{
    #region [ CTor ]

    public HomeThirdItemUserControl()
    {
        this.InitializeComponent();
    }
    #endregion

    #region [ Properties ]



    public Home_ThirdSectionItemModel ComponentData
    {
        get { return (Home_ThirdSectionItemModel)GetValue(ComponentDataProperty); }
        set { SetValue(ComponentDataProperty, value); }
    }

    public static readonly DependencyProperty ComponentDataProperty =
        DependencyProperty.Register("ComponentData", typeof(Home_ThirdSectionItemModel), typeof(HomeThirdItemUserControl), null);


    #endregion
}
