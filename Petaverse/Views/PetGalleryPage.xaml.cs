using Petaverse.ContentDialogs;
using PetaVerse.Models.DTOs;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using System;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Media.Imaging;
using System.Linq;
using Windows.UI.Xaml.Media;
using Windows.UI.Composition;
using Windows.UI.Xaml.Hosting;
using Microsoft.Toolkit.Uwp.UI.Animations.Expressions;
using Microsoft.Graphics.Canvas.Effects;
using System.Numerics;
using EF = Microsoft.Toolkit.Uwp.UI.Animations.Expressions.ExpressionFunctions;

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

        //public ObservableCollection<BitmapImage> UploadMedia { get; set; } = new ObservableCollection<BitmapImage>();

        CompositionPropertySet _props;
        CompositionPropertySet _scrollerPropertySet;
        Compositor             _compositor;

        public PetGalleryPage()
        {
            this.InitializeComponent();
            this.InitAnimationHeader();
        }

        private async void AddPetMedia_Click(object sender, RoutedEventArgs e)
        {
            var addMediaDialog = new AddPetMediaContentDialog();
            addMediaDialog.PrimaryButtonClick += AddMediaDialog_PrimaryButtonClick;
            await addMediaDialog.ShowAsync();
        }

        private void AddMediaDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            var photos = (sender as AddPetMediaContentDialog).UploadMedia;
            //photos.ToList().ForEach(photo => Pet.PetPhotos);
        }

        private void InitAnimationHeader()
        {
            // Get the PropertySet that contains the scroll values from the ScrollViewer
            _scrollerPropertySet = ElementCompositionPreview.GetScrollViewerManipulationPropertySet(TheScrollView);
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

            // Create and start an ExpressionAnimation to track scroll progress over the desired distance
            ExpressionNode progressAnimation = EF.Clamp(-scrollingProperties.Translation.Y / clampSizeNode, 0, 1);
            _props.StartAnimation("progress", progressAnimation);

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
            Visual bioVisual                  = ElementCompositionPreview.GetElementVisual(Bio);
            Visual textVisual                 = ElementCompositionPreview.GetElementVisual(TextContainer);
            Visual buttonVisual               = ElementCompositionPreview.GetElementVisual(ButtonPanel);
            Visual petNameVisual              = ElementCompositionPreview.GetElementVisual(PetName);
            Visual breedInfoVisual            = ElementCompositionPreview.GetElementVisual(BreedInfo);
            Visual overlayRectangleVisual     = ElementCompositionPreview.GetElementVisual(OverlayRectangle);
            Visual staticInfoStackPanelVisual = ElementCompositionPreview.GetElementVisual(StaticInfoStackPanel);

            // Create an ExpressionAnimation that moves between 1 and 0 with scroll progress, to be used for text block opacity
            ExpressionNode textOpacityAnimation = EF.Clamp(1 - (progressNode * 2), 0, 1);

            // Start opacity and scale animations on the text block visuals

            petNameVisual.StartAnimation("Offset.X", progressNode * -40);
            petNameVisual.StartAnimation("Offset.Y", progressNode * 40);

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

            buttonVisual.StartAnimation("Offset.X", progressNode * -40);
            buttonVisual.StartAnimation("Offset.Y", progressNode * -100);
            //buttonVisual.StartAnimation("Offset.Y", progressNode * -40);

            ExpressionNode contentOffsetAnimation = progressNode * 100;
            textVisual.StartAnimation("Offset.Y", contentOffsetAnimation);

            //ExpressionNode buttonOffsetAnimation = progressNode * -100;
            //buttonVisual.StartAnimation("Offset.Y", buttonOffsetAnimation);
            //buttonVisual.StartAnimation("Offset.X", progressNode * -40);
        }
    }
}
