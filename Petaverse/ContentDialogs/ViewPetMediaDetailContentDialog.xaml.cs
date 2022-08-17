using Petaverse.Models.DTOs;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;

namespace Petaverse.ContentDialogs
{
    public sealed partial class ViewPetMediaDetailContentDialog : ContentDialog
    {
        public PetaverseMedia PetaverseMedia
        {
            get { return (PetaverseMedia)GetValue(PetaverseMediaProperty); }
            set { SetValue(PetaverseMediaProperty, value); }
        }

        public static readonly DependencyProperty PetaverseMediaProperty =
            DependencyProperty.Register("PetaverseMedia", typeof(PetaverseMedia), typeof(ViewPetMediaDetailContentDialog), new PropertyMetadata(null));


        public ViewPetMediaDetailContentDialog()
        {
            this.InitializeComponent();
        }

        private async void ContentDialog_Loaded(object sender, RoutedEventArgs e)
        {
            var anim = ConnectedAnimationService.GetForCurrentView().GetAnimation("ForwardConnectedAnimation");
            if (anim != null)
            {
                anim.TryStart(MediaDetail);
            }

            //From Stuhub
            //await Task.Delay(3500);
            //SchoolShimmer.Opacity = 0.0;
            //await Task.Delay(2000);
            //SchoolGrid.Opacity = 1.0;
        }

        private void CloseButton_Clicked(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
