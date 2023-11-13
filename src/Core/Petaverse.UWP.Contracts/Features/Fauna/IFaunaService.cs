using System.Collections.Generic;

namespace Petaverse.UWP.Contracts;

public interface IFaunaService
{
    Task<IEnumerable<Species>> GetSpeciesListAsync();
}
