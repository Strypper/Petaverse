﻿using Petaverse.ContentDialogs;
using System;
using System.Linq;
using System.Numerics;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;
using Windows.UI.Composition;
using Windows.UI.Xaml.Hosting;
using Windows.UI.Xaml.Controls;
using Microsoft.Graphics.Canvas.Effects;
using WinRTXamlToolkit.Controls.Extensions;
using Microsoft.Toolkit.Uwp.UI.Animations.Expressions;
using EF = Microsoft.Toolkit.Uwp.UI.Animations.Expressions.ExpressionFunctions;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media.Imaging;
using Petaverse.Models.DTOs;
using CommunityToolkit.Mvvm.Input;
using Petaverse.Interfaces;
using CommunityToolkit.Mvvm.DependencyInjection;
using Petaverse.Models.Others;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        Compositor             _compositor;
        CompositionPropertySet _props;
        CompositionPropertySet _scrollerPropertySet;
        SpriteVisual           _blurredBackgroundImageVisual;

        public delegate void DeletePetEventHandler(int petId);
        public event DeletePetEventHandler DeletePetClick;

        public delegate void SelectImageEventHandler(PetaverseMedia petaverseMedia);
        public event SelectImageEventHandler SelectPhoto;

        private IUploadPetFileService _uploadPetFileService;

        public PetGalleryPage()
        {
            this.InitializeComponent();
            this._uploadPetFileService = Ioc.Default.GetRequiredService<IUploadPetFileService>();
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            this.InitAnimationHeader();
        }

        private void InitAnimationHeader()
        {
            var scrollViewer = PetGalleryAdaptiveGridView.GetFirstDescendantOfType<ScrollViewer>();

            var headerPresenter = (UIElement)VisualTreeHelper.GetParent((UIElement)PetGalleryAdaptiveGridView.Header);
            var headerContainer = (UIElement)VisualTreeHelper.GetParent(headerPresenter);
            Canvas.SetZIndex((UIElement)headerContainer, 1);

            // Get the PropertySet that contains the scroll values from the ScrollViewer
            _scrollerPropertySet = ElementCompositionPreview.GetScrollViewerManipulationPropertySet(scrollViewer);
            _compositor = _scrollerPropertySet.Compositor;

            // Create a PropertySet that has values to be referenced in the ExpressionAnimations below
            _props = _compositor.CreatePropertySet();
            _props.InsertScalar("progress", 0);
            _props.InsertScalar("clampSize", 150);
            _props.InsertScalar("scaleFactor", 0.7f);

            // Get references to our property sets for use with ExpressionNodes
            var scrollingProperties = _scrollerPropertySet.GetSpecializedReference<ManipulationPropertySetReferenceNode>();
            var props = _props.GetReference();
            var progressNode = props.GetScalarProperty("progress");
            var clampSizeNode = props.GetScalarProperty("clampSize");
            var scaleFactorNode = props.GetScalarProperty("scaleFactor");

            // Create a blur effect to be animated based on scroll position
            var blurEffect = new GaussianBlurEffect()
            {
                Name = "blur",
                BlurAmount = 0.0f,
                BorderMode = EffectBorderMode.Hard,
                Optimization = EffectOptimization.Balanced,
                Source = new CompositionEffectSourceParameter("source")
            };

            var blurBrush = _compositor.CreateEffectFactory(
                blurEffect,
                new[] { "blur.BlurAmount" })
                .CreateBrush();

            blurBrush.SetSourceParameter("source", _compositor.CreateBackdropBrush());

            _blurredBackgroundImageVisual = _compositor.CreateSpriteVisual();
            _blurredBackgroundImageVisual.Brush = blurBrush;
            _blurredBackgroundImageVisual.Size = new Vector2((float)OverlayRectangle.ActualWidth, (float)OverlayRectangle.ActualHeight);

            // Insert the blur visual at the right point in the Visual Tree
            ElementCompositionPreview.SetElementChildVisual(OverlayRectangle, _blurredBackgroundImageVisual);

            // Create and start an ExpressionAnimation to track scroll progress over the desired distance
            ExpressionNode progressAnimation = EF.Clamp(-scrollingProperties.Translation.Y / clampSizeNode, 0, 1);
            _props.StartAnimation("progress", progressAnimation);

            ExpressionNode blurAnimation = EF.Lerp(0, 15, progressNode);
            _blurredBackgroundImageVisual.Brush.Properties.StartAnimation("blur.BlurAmount", blurAnimation);

            // Get the backing visual for the header so that its properties can be animated
            Visual headerVisual = ElementCompositionPreview.GetElementVisual(Header);

            // Create and start an ExpressionAnimation to clamp the header's offset to keep it onscreen
            ExpressionNode headerTranslationAnimation = EF.Conditional(progressNode < 1, 0, -scrollingProperties.Translation.Y - clampSizeNode);
            headerVisual.StartAnimation("Offset.Y", headerTranslationAnimation);

            // Create and start an ExpressionAnimation to scale the header during overpan
            ExpressionNode headerScaleAnimation = EF.Lerp(1, 1.25f, EF.Clamp(scrollingProperties.Translation.Y / 50, 0, 1));
            headerVisual.StartAnimation("Scale.X", headerScaleAnimation);
            headerVisual.StartAnimation("Scale.Y", headerScaleAnimation);

            //Set the header's CenterPoint to ensure the overpan scale looks as desired
            headerVisual.CenterPoint = new Vector3((float)(Header.ActualWidth / 2), (float)Header.ActualHeight, 0);

            // Get the backing visual for the photo in the header so that its properties can be animated
            Visual photoVisual = ElementCompositionPreview.GetElementVisual(BackgroundRectangle);

            // Create and start an ExpressionAnimation to opacity fade out the image behind the header
            ExpressionNode imageOpacityAnimation = 1 - progressNode;
            photoVisual.StartAnimation("opacity", imageOpacityAnimation);

            // Get the backing visual for the profile picture visual so that its properties can be animated
            Visual profileVisual = ElementCompositionPreview.GetElementVisual(ProfileImage);

            // Create and start an ExpressionAnimation to scale the profile image with scroll position
            ExpressionNode scaleAnimation = EF.Lerp(1, scaleFactorNode, progressNode);

            profileVisual.StartAnimation("Scale.X", scaleAnimation);
            profileVisual.StartAnimation("Scale.Y", scaleAnimation);

            // Get backing visuals for the text blocks so that their properties can be animated
            Visual bioVisual = ElementCompositionPreview.GetElementVisual(Bio);
            Visual textVisual = ElementCompositionPreview.GetElementVisual(TextContainer);
            Visual buttonVisual = ElementCompositionPreview.GetElementVisual(ButtonPanel);
            Visual petNameVisual = ElementCompositionPreview.GetElementVisual(PetName);
            Visual breedInfoVisual = ElementCompositionPreview.GetElementVisual(BreedInfo);
            Visual overlayRectangleVisual = ElementCompositionPreview.GetElementVisual(OverlayRectangle);
            Visual staticInfoStackPanelVisual = ElementCompositionPreview.GetElementVisual(StaticInfoStackPanel);

            // Create an ExpressionAnimation that moves between 1 and 0 with scroll progress, to be used for text block opacity
            ExpressionNode textOpacityAnimation = EF.Clamp(1 - (progressNode * 2), 0, 1);

            // Start opacity and scale animations on the text block visuals

            petNameVisual.StartAnimation("Offset.X", progressNode * -40);
            petNameVisual.StartAnimation("Offset.Y", progressNode * 20);

            //overlayRectangleVisual.StartAnimation("Opacity", EF.Clamp(1, 0, 1));

            bioVisual.StartAnimation("Opacity", textOpacityAnimation);
            bioVisual.StartAnimation("Scale.X", scaleAnimation);
            bioVisual.StartAnimation("Scale.Y", scaleAnimation);

            breedInfoVisual.StartAnimation("Opacity", textOpacityAnimation);
            breedInfoVisual.StartAnimation("Scale.X", scaleAnimation);
            breedInfoVisual.StartAnimation("Scale.Y", scaleAnimation);

            staticInfoStackPanelVisual.StartAnimation("Opacity", textOpacityAnimation);
            staticInfoStackPanelVisual.StartAnimation("Scale.X", scaleAnimation);
            staticInfoStackPanelVisual.StartAnimation("Scale.Y", scaleAnimation);

            buttonVisual.StartAnimation("Offset.X", progressNode * -50);
            buttonVisual.StartAnimation("Offset.Y", progressNode * -90);
            //buttonVisual.StartAnimation("Offset.Y", progressNode * -40);

            ExpressionNode contentOffsetAnimation = progressNode * 100;
            textVisual.StartAnimation("Offset.Y", contentOffsetAnimation);

            //ExpressionNode buttonOffsetAnimation = progressNode * -100;
            //buttonVisual.StartAnimation("Offset.Y", buttonOffsetAnimation);
            //buttonVisual.StartAnimation("Offset.X", progressNode * -40);
        }

        private async void AddPetMedia_Click(object sender, RoutedEventArgs e)
        {
            var addMediaDialog = new AddPetMediaContentDialog()
            {
                UploadPhotosCommand = UploadPhotoCommand
            };
            await addMediaDialog.ShowAsync();
        }

        [RelayCommand]
        async Task UploadPhotoAsync(List<PetPhotosStream> petPhotosStream)
        {
            await _uploadPetFileService.UploadMultiplePetFilesAsync(Pet.Id, petPhotosStream);
        }

        private void PetGalleryAdaptiveGridView_DoubleTapped(object sender, Windows.UI.Xaml.Input.DoubleTappedRoutedEventArgs e)
        {
            var SelectedPhoto = PetGalleryAdaptiveGridView.SelectedItem as PetaverseMedia;
            if(SelectedPhoto != null)
            {
                PetGalleryAdaptiveGridView.PrepareConnectedAnimation("ForwardConnectedAnimation", SelectedPhoto, "PetMedia");
                SelectPhoto.Invoke(SelectedPhoto);
            }
        }

        private void DeletePet_Click(object sender, RoutedEventArgs e)
          => DeletePetClick?.Invoke(Pet.Id);
    }

    public class SwapStringToBitmapImageSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var media = (PetaverseMedia)value;
            if (string.IsNullOrEmpty(media.MediaUrl))
            {
                return media.LocalImage != null ? media.LocalImage : null;  
            }
            else return new BitmapImage(new Uri(media.MediaUrl));
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
