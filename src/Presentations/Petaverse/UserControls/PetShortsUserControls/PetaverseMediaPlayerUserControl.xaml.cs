using CommunityToolkit.Mvvm.ComponentModel;
using Petaverse.Models.DTOs;
using System;
using Windows.Media.Core;
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

        public PetaverseMediaPlayerUserControl()
        {
            this.InitializeComponent();
            var a = ViewportBehavior.IsInViewport;
        }

        private void PetShortMediaPlayer_ToggleLoveEvent(object sender, EventArgs e)
        {
            PetShort.IsLoved = !PetShort.IsLoved;
            PetShort.Love += (PetShort.IsLoved ? 1 : -1);
        }

        private void Element_EnteredViewport(object sender, EventArgs e)
        {
        }

        private void Element_EnteringViewport(object sender, EventArgs e)
        {
            // A part of the control enter the ScrollViewer viewport
        }

        private void Element_ExitedViewport(object sender, EventArgs e)
        {
        }

        private void Element_ExitingViewport(object sender, EventArgs e)
        {
            // A part of the control outside of the ScrollViewer viewport
        }


    }
}
