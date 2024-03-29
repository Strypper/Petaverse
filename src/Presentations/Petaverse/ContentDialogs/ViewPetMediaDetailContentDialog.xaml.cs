﻿using Windows.UI.Xaml.Media.Animation;

namespace Petaverse.ContentDialogs;

public sealed partial class ViewPetMediaDetailContentDialog : ContentDialog
{
    public Models.DTOs.PetaverseMedia PetaverseMedia
    {
        get { return (Models.DTOs.PetaverseMedia)GetValue(PetaverseMediaProperty); }
        set { SetValue(PetaverseMediaProperty, value); }
    }

    public static readonly DependencyProperty PetaverseMediaProperty =
        DependencyProperty.Register("PetaverseMedia", typeof(Models.DTOs.PetaverseMedia), typeof(ViewPetMediaDetailContentDialog), new PropertyMetadata(null));


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
    }

    private void CloseButton_Clicked(object sender, RoutedEventArgs e)
    {
        this.Hide();
    }
}
