namespace Petaverse.Views;

public sealed partial class WikiPage : Page
{
    public ObservableCollection<Models.DTOs.Species> Species { get; set; } = new ObservableCollection<Models.DTOs.Species>();

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

    private ObservableCollection<Models.DTOs.Species> LoadPetaverseSpeciesData()
    {
        var species = new ObservableCollection<Models.DTOs.Species>();
        species.Add(new Models.DTOs.Species()
        {
            Name = "Cats",
            Icon = "CatIcon",
            Color = "#ffb900",
            Breeds = DemoBreedData.GetBreedsList()
        });
        species.Add(new Models.DTOs.Species()
        {
            Name = "Dogs",
            Icon = "DogIcon",
            Color = "#ffd679",
            //Breeds = DemoBreedData.GetBreedsList()
        });
        species.Add(new Models.DTOs.Species()
        {
            Name = "Fishes",
            Icon = "FisheIcon",
            Color = "#00bcf2",
            //Breeds = DemoBreedData.GetBreedsList()
        });
        species.Add(new Models.DTOs.Species()
        {
            Name = "Birds",
            Icon = "BirdIcon",
            Color = "#00bcf2",
            //Breeds = DemoBreedData.GetBreedsList()
        });
        return species;
    }

}
