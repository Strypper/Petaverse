namespace Petaverse;

public sealed partial class HomeFirstItemUserControl : UserControl
{

    #region [ CTors ]

    public HomeFirstItemUserControl()
    {
        this.InitializeComponent();
    }
    #endregion

    #region [ Properties ]



    public Home_FirstSectionItemModel ComponentData
    {
        get { return (Home_FirstSectionItemModel)GetValue(ComponentDataProperty); }
        set { SetValue(ComponentDataProperty, value); }
    }

    public static readonly DependencyProperty ComponentDataProperty =
        DependencyProperty.Register("ComponentData", typeof(Home_FirstSectionItemModel), typeof(HomeFirstItemUserControl), null);


    #endregion
}
