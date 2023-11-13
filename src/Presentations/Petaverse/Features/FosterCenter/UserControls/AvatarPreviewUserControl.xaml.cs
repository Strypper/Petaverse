using Windows.UI.Xaml.Media;

namespace Petaverse.FosterCenter;

public sealed partial class AvatarPreviewUserControl : UserControl
{

    #region [ CTor ]

    public AvatarPreviewUserControl()
    {
        this.InitializeComponent();
    }
    #endregion

    #region [ Delegates ]


    public delegate void SelectItemEventHandler(string itemId);
    #endregion

    #region [ Properties ]

    public string ComponentId
    {
        get { return (string)GetValue(ComponentIdProperty); }
        set { SetValue(ComponentIdProperty, value); }
    }

    public static readonly DependencyProperty ComponentIdProperty =
        DependencyProperty.Register("ComponentId", typeof(string), typeof(AvatarPreviewUserControl), new PropertyMetadata(string.Empty));



    public string Title
    {
        get { return (string)GetValue(TitleProperty); }
        set { SetValue(TitleProperty, value); }
    }

    public static readonly DependencyProperty TitleProperty =
        DependencyProperty.Register("Title", typeof(string), typeof(AvatarPreviewUserControl), null);



    public string ImageUrl
    {
        get { return (string)GetValue(ImageUrlProperty); }
        set { SetValue(ImageUrlProperty, value); }
    }

    public static readonly DependencyProperty ImageUrlProperty =
        DependencyProperty.Register("ImageUrl", typeof(string), typeof(AvatarPreviewUserControl), null);



    public string AdditionalInfo
    {
        get { return (string)GetValue(AdditionalInfoProperty); }
        set { SetValue(AdditionalInfoProperty, value); }
    }

    public static readonly DependencyProperty AdditionalInfoProperty =
        DependencyProperty.Register("AdditionalInfo", typeof(string), typeof(AvatarPreviewUserControl), null);



    public SolidColorBrush AdditionalInfoBackgroundColorBrush
    {
        get { return (SolidColorBrush)GetValue(AdditionalInfoBackgroundColorBrushProperty); }
        set { SetValue(AdditionalInfoBackgroundColorBrushProperty, value); }
    }

    public static readonly DependencyProperty AdditionalInfoBackgroundColorBrushProperty =
        DependencyProperty.Register("AdditionalInfoBackgroundColorBrush", typeof(SolidColorBrush), typeof(AvatarPreviewUserControl), new PropertyMetadata(null));


    #endregion

    #region [ Event Handler ]


    public event SelectItemEventHandler SelectItem;

    private void AvatarDetailButton_Click(object sender, RoutedEventArgs e) { }
    //=> SelectItem?.Invoke(ComponentId);
    private void Component_PointerPressed(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        => SelectItem?.Invoke(ComponentId);
    #endregion

}
