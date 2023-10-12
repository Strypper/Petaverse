namespace Petaverse;

public sealed partial class HomeCarouselItemUserControl : UserControl
{

    #region [ CTors ]

    public HomeCarouselItemUserControl()
    {
        this.InitializeComponent();
    }
    #endregion

    #region [ Properties ]



    public HomeCarouselItemUserControlModel ComponentData
    {
        get { return (HomeCarouselItemUserControlModel)GetValue(ComponentDataProperty); }
        set { SetValue(ComponentDataProperty, value); }
    }

    public static readonly DependencyProperty ComponentDataProperty =
        DependencyProperty.Register("ComponentData", typeof(HomeCarouselItemUserControlModel), typeof(HomeCarouselItemUserControl), null);


    #endregion
}
