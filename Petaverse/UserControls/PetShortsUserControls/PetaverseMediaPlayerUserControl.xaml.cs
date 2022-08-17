using Petaverse.Models.DTOs;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Petaverse.UserControls.PetShortsUserControls
{
    public sealed partial class PetaverseMediaPlayerUserControl : UserControl
    {
        public PetShort PetShort
        {
            get { return (PetShort)GetValue(PetShortProperty); }
            set { SetValue(PetShortProperty, value); }
        }

        public static readonly DependencyProperty PetShortProperty =
            DependencyProperty.Register("PetShort", typeof(PetShort), typeof(PetaverseMediaPlayerUserControl), null);

        private bool isToggledLove;

        public PetaverseMediaPlayerUserControl()
        {
            this.InitializeComponent();
        }

        private void HeartButton_Click(object sender, RoutedEventArgs e)
        {
            PetShort.Love += (isToggledLove ? 1 : -1);
            isToggledLove = !isToggledLove;
        }
    }
}
