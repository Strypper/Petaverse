using CommunityToolkit.Mvvm.DependencyInjection;
using Petaverse.Interfaces.PetaverseAPI;
using Petaverse.Models.DTOs;
using Petaverse.Refits;
using Petaverse.ViewModels;
using Refit;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using Windows.UI.Xaml.Controls;

namespace Petaverse.Views
{
    public sealed partial class WikiPage : Page
    {
        public ObservableCollection<Species> Species { get; set; } = new ObservableCollection<Species>();

        private readonly ISpeciesService _speciestService;
        public WikiPage()
        {
            this.InitializeComponent();
            _speciestService = Ioc.Default.GetRequiredService<ISpeciesService>();

        }
        private async void Page_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var species = await _speciestService.GetAllAsync();
            if (species != null)
                species.ToList().ForEach(s => Species.Add(s));
        }

        private ObservableCollection<Species> LoadPetaverseSpeciesData()
        {
            var species = new ObservableCollection<Species>();
            species.Add(new Species()
            {
                Name = "Cats",
                Icon = "CatIcon",
                Color = "#ffb900",
                Breeds = DemoBreedData.GetBreedsList()
            });
            species.Add(new Species()
            {
                Name = "Dogs",
                Icon = "DogIcon",
                Color = "#ffd679",
                //Breeds = DemoBreedData.GetBreedsList()
            });
            species.Add(new Species()
            {
                Name = "Fishes",
                Icon = "FisheIcon",
                Color = "#00bcf2",
                //Breeds = DemoBreedData.GetBreedsList()
            });
            species.Add(new Species()
            {
                Name = "Birds",
                Icon = "BirdIcon",
                Color = "#00bcf2",
                //Breeds = DemoBreedData.GetBreedsList()
            });
            return species;
        }

    }
}
