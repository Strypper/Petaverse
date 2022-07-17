using Petaverse.ViewModels;
using PetaVerse.Models.DTOs;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Controls;

namespace Petaverse.Views
{
    public sealed partial class WikiPage : Page
    {
        public ObservableCollection<Species> Species { get; set; }
        public WikiPage()
        {
            this.InitializeComponent();
            Species = LoadPetaverseSpeciesData();
        }

        private ObservableCollection<Species> LoadPetaverseSpeciesData()
        {
            var species = new ObservableCollection<Species>();
            species.Add(new Species()
            {
                Name = "Cats",
                Icon = "\U0001F408",
                Color = "#ffb900",
                Breeds = DemoBreedData.GetBreedsList()
            });
            species.Add(new Species()
            {
                Name = "Dogs",
                Icon = "\U0001F415",
                Color = "#ffd679",
                //Breeds = DemoBreedData.GetBreedsList()
            });
            species.Add(new Species()
            {
                Name = "Fishes",
                Icon = "\U0001F41F",
                Color = "#00bcf2",
                //Breeds = DemoBreedData.GetBreedsList()
            });
            return species;
        }
    }
}
