
namespace Petaverse.UWP.LogicProvider.Offline;

public class FaunaService : IFaunaService
{
    #region [ CTor ]

    public FaunaService()
    {

    }
    #endregion

    #region [ Methods ]

    public Task<IEnumerable<Species>> GetSpeciesListAsync()
    {
        throw new NotImplementedException();
    }
    #endregion
}
