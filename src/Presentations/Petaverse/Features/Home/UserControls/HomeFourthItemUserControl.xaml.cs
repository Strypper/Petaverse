namespace Petaverse.Home;

public sealed partial class HomeFourthItemUserControl : UserControl
{
    #region [ CTor ]

    public HomeFourthItemUserControl()
    {
        this.InitializeComponent();
    }
    #endregion

    #region [ Properties ]

    public Home_FourthSectionItemModel ComponentData
    {
        get { return (Home_FourthSectionItemModel)GetValue(ComponentDataProperty); }
        set { SetValue(ComponentDataProperty, value); }
    }

    public static readonly DependencyProperty ComponentDataProperty =
        DependencyProperty.Register("ComponentData", typeof(Home_FourthSectionItemModel), typeof(Home_FourthSectionItemModel), null);


    #endregion
}
