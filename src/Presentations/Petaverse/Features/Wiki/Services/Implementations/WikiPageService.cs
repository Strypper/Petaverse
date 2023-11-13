using WinRTXamlToolkit.Tools;

namespace Petaverse.Wiki;

public class WikiPageService : IWikiPageService
{

    #region [ Fields ]

    private readonly IFaunaService faunaService;
    #endregion

    #region [ CTors ]

    public WikiPageService(IFaunaService faunaService)
    {
        this.faunaService = faunaService;
    }
    #endregion

    #region [ Methods ]

    #endregion
    public Task<IReadOnlyCollection<Species>> GetAllSpecies()
    {
        var result = faunaService.GetSpeciesListAsync();
        List<Species> species = new();
        result.Result.ForEach(x =>
        {
            List<Breed> breeds = new();
            if (x.Breeds.Any())
                x.Breeds.ForEach(y => breeds.Add(new()
                {
                    Id = y.Id,
                    Name = y.Name,
                    Colors = y.Colors,
                    ImageUrl = y.ImageUrl,
                    Coat = CoreCoatToUICoat.Convert(y.Coat),
                    Energy = CoreEnergyToUIEnergy.Convert(y.Energy),
                    Shedding = CoreSheddingToUIShedding.Convert(y.Shedding),
                    Size = CoreSizeToUISize.Convert(y.Size),
                    Description = y.Description,
                    MinimunSize = y.MinimumSize,
                    MaximumSize = y.MaximumSize,
                    MinimumWeight = y.MinimumWeight,
                    MaximumWeight = y.MaximumWeight,
                    MinimumLifeSpan = y.MinimumLifeSpan,
                    MaximumLifeSpan = y.MaximumLifeSpan,
                    CreatedOn = y.CreatedOn,
                    LastUpdatedOn = y.LastUpdatedOn
                }));

            species.Add(new()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Icon = x.Icon,
                Color = x.Color,
                Breeds = new(breeds),
                CreatedOn = x.CreatedOn,
                LastUpdatedOn = x.LastUpdatedOn
            });
        });

        IReadOnlyCollection<Species> readOnlySpecies = species.AsReadOnly();
        return Task.FromResult(readOnlySpecies);
    }
}
