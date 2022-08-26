using CommunityToolkit.Mvvm.ComponentModel;
using Petaverse.Models.DTOs;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Petaverse.UserControls.PetShortsUserControls
{
    [INotifyPropertyChanged]
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

        [ObservableProperty]
        bool isVisibleVideoTitle;

        public PetaverseMediaPlayerUserControl()
        {
            this.InitializeComponent();
        }

        private void HeartButton_Click(object sender, RoutedEventArgs e)
        {
            PetShort.Love += (isToggledLove ? 1 : -1);
            isToggledLove = !isToggledLove;
        }

        private void Grid_PointerEntered(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            IsVisibleVideoTitle = true;
        }

        private void Grid_PointerExited(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            IsVisibleVideoTitle = false;
        }
    }
}
