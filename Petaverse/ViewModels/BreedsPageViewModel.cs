using PetaVerse.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
