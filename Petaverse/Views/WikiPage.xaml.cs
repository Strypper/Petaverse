using Petaverse.Refits;
using Petaverse.ViewModels;
using PetaVerse.Models.DTOs;
using Refit;
using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using Windows.UI.Xaml.Controls;

namespace Petaverse.Views
{
    public sealed partial class WikiPage : Page
    {
        public ObservableCollection<Species> Species { get; set; } = new ObservableCollection<Species>();

        private readonly ISpeciesData speciestData = RestService.For<ISpeciesData>(new HttpClient(new HttpClientHandler()
        {
            ServerCertificateCustomValidationCallback = (message, cert, chain, sslErrors) => true
        })
        {
            BaseAddress = new Uri("https://localhost:5001/api")
        });
        public WikiPage()
        {
            this.InitializeComponent();
        }
        private async void Page_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var species = await speciestData.GetAllSpecies();
            species.ForEach(s => Species.Add(s));
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
