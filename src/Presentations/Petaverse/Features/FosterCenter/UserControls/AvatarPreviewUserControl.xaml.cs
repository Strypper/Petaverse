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

    public string Title
    {
        get { return (string)GetValue(TitleProperty); }
        set { SetValue(TitleProperty, value); }
    }

    public static readonly DependencyProperty TitleProperty =
        DependencyProperty.Register("Title", typeof(string), typeof(string), null);



    public string ImageUrl
    {
        get { return (string)GetValue(ImageUrlProperty); }
        set { SetValue(ImageUrlProperty, value); }
    }

    public static readonly DependencyProperty ImageUrlProperty =
        DependencyProperty.Register("ImageUrl", typeof(string), typeof(string), null);



    public string AdditionalInfo
    {
        get { return (string)GetValue(AdditionalInfoProperty); }
        set { SetValue(AdditionalInfoProperty, value); }
    }

    public static readonly DependencyProperty AdditionalInfoProperty =
        DependencyProperty.Register("AdditionalInfo", typeof(string), typeof(string), null);



    #endregion
}
