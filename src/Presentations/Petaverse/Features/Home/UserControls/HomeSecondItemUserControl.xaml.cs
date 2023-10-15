namespace Petaverse.Home;

public sealed partial class HomeSecondItemUserControl : UserControl
{
    #region [ Delegates ]

    public delegate void SelectItemEventHandler(Home_SecondSectionItemModel item);
    #endregion

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


    #region [ Events Handler ]

    public event SelectItemEventHandler SelectItem;

    private void RelativePanel_PointerPressed(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        => SelectItem?.Invoke(ComponentData);
    #endregion

}
