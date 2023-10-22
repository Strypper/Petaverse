namespace Petaverse.PersonalProfile;

public sealed partial class PetGalleryGridViewItemUserControl : UserControl
{
    public Models.DTOs.PetaverseMedia PetaverseMedia
    {
        get { return (Models.DTOs.PetaverseMedia)GetValue(PetaverseMediaProperty); }
        set { SetValue(PetaverseMediaProperty, value); }
    }

    public static readonly DependencyProperty PetaverseMediaProperty =
        DependencyProperty.Register("PetaverseMedia", typeof(Models.DTOs.PetaverseMedia), typeof(PetGalleryGridViewItemUserControl), null);


    public PetGalleryGridViewItemUserControl()
    {
        this.InitializeComponent();
    }
}
