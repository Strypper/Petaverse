namespace Petaverse;

public sealed partial class HomeSecondItemUserControl : UserControl
{
    #region [ CTors ]

    public HomeSecondItemUserControl()
    {
        this.InitializeComponent();
    }
    #endregion

    #region [ Properties ]

    public Home_SecondSectionItemModel ComponentData
    {
        get { return (Home_SecondSectionItemModel)GetValue(ComponentDataProperty); }
        set { SetValue(ComponentDataProperty, value); }
    }

    public static readonly DependencyProperty ComponentDataProperty =
        DependencyProperty.Register("ComponentData", typeof(Home_SecondSectionItemModel), typeof(HomeSecondItemUserControl), null);


    #endregion
}
