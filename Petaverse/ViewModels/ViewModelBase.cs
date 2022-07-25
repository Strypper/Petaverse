
using CommunityToolkit.Mvvm.ComponentModel;

namespace Petaverse.ViewModels
{
    public partial class ViewModelBase : ObservableRecipient
    {
        [ObservableProperty]
        bool isBusy;
        public ViewModelBase() { }
    }
    //public partial class ViewModelBase
    //{
    //    public ViewModelBase() { }
    //}
}
