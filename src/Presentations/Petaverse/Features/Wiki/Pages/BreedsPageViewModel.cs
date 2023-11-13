using Petaverse.ViewModels;

namespace Petaverse.Wiki;

public partial class BreedsPageViewModel : ViewModelBase
{
    public ObservableCollection<Models.DTOs.Breed> Breeds { get; set; } = new ObservableCollection<Models.DTOs.Breed>();
    public BreedsPageViewModel()
    {
        Breeds = DemoBreedData.GetBreedsList();
    }
}
