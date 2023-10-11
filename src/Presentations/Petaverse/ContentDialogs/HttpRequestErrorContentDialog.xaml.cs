using Refit;
using System.Net;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;


namespace Petaverse.ContentDialogs
{
    public sealed partial class HttpRequestErrorContentDialog : ContentDialog
    {
        public ApiException Exception
        {
            get { return (ApiException)GetValue(ExceptionProperty); }
            set { SetValue(ExceptionProperty, value); }
        }

        public static readonly DependencyProperty ExceptionProperty =
            DependencyProperty.Register("Exception", typeof(ApiException), 
                                                     typeof(HttpRequestErrorContentDialog), 
                                                     null);


        public HttpRequestErrorContentDialog()
        {
            this.InitializeComponent();
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }

        private static int GetHttpErrorCode(HttpStatusCode code)  => (int)code;
    }
}
