using System.Collections.Generic;
using System.Net.Http;
using Windows.UI.Xaml.Controls;

namespace Petaverse.ContentDialogs
{
    public sealed partial class ServerNotFoundContentDialog : ContentDialog
    {
        public HttpClient HttpClientInfo { get; set; }
        public string DestinationTryingToReach { get; set; } = string.Empty;
        public string ServiceImageUrl { get; set; } = string.Empty;
        public string Action { get; set; } = string.Empty;
        public List<string> SolutionsList { get; set; } = new List<string>();
        public List<string> ProblemsCouldCauseList { get; set; } = new List<string>();
        public ServerNotFoundContentDialog()
        {
            this.InitializeComponent();
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }
    }
}
