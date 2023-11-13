namespace Petaverse.Wiki;

public interface IWikiPageService
{
    Task<IReadOnlyCollection<Species>> GetAllSpecies();
}
