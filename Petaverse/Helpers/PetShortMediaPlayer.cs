using Petaverse.Models.DTOs;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;

namespace Petaverse.Helpers
{
    public sealed class PetShortMediaPlayer : MediaTransportControls
    {
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(PetShortMediaPlayer), new PropertyMetadata(null));



        public bool IsLoved
        {
            get { return (bool)GetValue(IsLovedProperty); }
            set { SetValue(IsLovedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsLoved.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsLovedProperty =
            DependencyProperty.Register("IsLoved", typeof(bool), typeof(PetShortMediaPlayer), new PropertyMetadata(false));



        public event EventHandler<EventArgs> ToggleLoveEvent;
        public PetShortMediaPlayer()
        {
            this.DefaultStyleKey = typeof(PetShortMediaPlayer);
        }

        protected override void OnApplyTemplate()
        {
            // This is where you would get your custom button and create an event handler for its click method.
            var heartButton = GetTemplateChild("HeartButton") as ToggleButton;
            heartButton.Click += HeartButton_Click;

            base.OnApplyTemplate();
        }

        private void HeartButton_Click(object sender, RoutedEventArgs e)
        {
            ToggleLoveEvent?.Invoke(this, EventArgs.Empty);
        }

    }
}
