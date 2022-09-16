using CommunityToolkit.Mvvm.ComponentModel;
using Petaverse.Models.DTOs;
using System;
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



        [ObservableProperty]
        bool isVisibleVideoTitle;

        public PetaverseMediaPlayerUserControl()
        {
            this.InitializeComponent();
        }

        private void Grid_PointerEntered(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            IsVisibleVideoTitle = true;
        }

        private void Grid_PointerExited(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            IsVisibleVideoTitle = false;
        }

        private void PetShortMediaPlayer_ToggleLoveEvent(object sender, EventArgs e)
        {
            PetShort.IsLoved = !PetShort.IsLoved;
            PetShort.Love += (PetShort.IsLoved ? 1 : -1);
        }
    }
}
