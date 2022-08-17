using Petaverse.Models.DTOs;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;

namespace Petaverse.UserControls.ProfilePageUserControls
{
    public sealed partial class PetGalleryGridViewItemUserControl : UserControl
    {
        public PetaverseMedia PetaverseMedia
        {
            get { return (PetaverseMedia)GetValue(PetaverseMediaProperty); }
            set { SetValue(PetaverseMediaProperty, value); }
        }

        public static readonly DependencyProperty PetaverseMediaProperty =
            DependencyProperty.Register("PetaverseMedia", typeof(PetaverseMedia), typeof(PetGalleryGridViewItemUserControl), null);


        public PetGalleryGridViewItemUserControl()
        {
            this.InitializeComponent();
        }
    }
}
