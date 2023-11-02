namespace Petaverse.BlackList;

public sealed partial class BlackListItemUserControl : UserControl
{

    #region [ CTor ]

    public BlackListItemUserControl()
    {
        this.InitializeComponent();
    }
    #endregion

    #region [ Properties ]

    public BlackListItemModel ComponentData
    {
        get { return (BlackListItemModel)GetValue(ComponentDataProperty); }
        set { SetValue(ComponentDataProperty, value); }
    }

    public static readonly DependencyProperty ComponentDataProperty =
        DependencyProperty.Register("ComponentData", typeof(BlackListItemModel), typeof(BlackListItemUserControl), new PropertyMetadata(null));


    #endregion

    private void BlackListItem_DoubleTapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
    {

    }
}
