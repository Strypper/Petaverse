using PetaVerse.Models.DTOs;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Petaverse.Views
{
    public sealed partial class PetGalleryPage : Page
    {
        public Animal Pet
        {
            get { return (Animal)GetValue(PetProperty); }
            set { SetValue(PetProperty, value); }
        }
        public static readonly DependencyProperty PetProperty =
            DependencyProperty.Register("Pet", typeof(Animal), typeof(PetGalleryPage), null);



        public PetGalleryPage()
        {
            this.InitializeComponent();
        }
    }
}
