using Petaverse.Models.DTOs;
using System.Collections.ObjectModel;

namespace Petaverse.ViewModels
{
    public partial class BreedsPageViewModel : ViewModelBase
    {
        public ObservableCollection<Breed> Breeds { get; set; } = new ObservableCollection<Breed>();
        public BreedsPageViewModel()
        {
            Breeds = DemoBreedData.GetBreedsList();
        }
    }
}
