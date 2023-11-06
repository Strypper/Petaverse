namespace Petaverse.PersonalProfile;

public sealed partial class PetGalleryGridViewItemUserControl : UserControl
{
    public ThumbnailModel ComponentData
    {
        get { return (ThumbnailModel)GetValue(ComponentDataProperty); }
        set { SetValue(ComponentDataProperty, value); }
    }

    public static readonly DependencyProperty ComponentDataProperty =
        DependencyProperty.Register("ComponentData", typeof(ThumbnailModel), typeof(PetGalleryGridViewItemUserControl), null);


    public PetGalleryGridViewItemUserControl()
    {
        this.InitializeComponent();
    }
}
