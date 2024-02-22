using Microsoft.EntityFrameworkCore;

namespace Petaverse.UWP.LogicProvider.Offline;

public class HomeService : IHomeService
{
    #region [ Fields ]

    private readonly PetaverseLocalDbContext context;
    protected readonly DbSet<HomePage_Carousels> homePage_Carousels;
    protected readonly DbSet<HomePage_TopFosterCenters> homePage_TopFosterCenters;
    #endregion

    #region [ CTors ]

    public HomeService(PetaverseLocalDbContext context)
    {
        this.context = context;
        this.homePage_Carousels = context.Set<HomePage_Carousels>();
        this.homePage_TopFosterCenters = context.Set<HomePage_TopFosterCenters>();

        this.context.Database.EnsureCreated();
    }

    #endregion

    #region [ Methods ]

    public async Task<IEnumerable<FosterCenter>> GetFosterCentersAsync()
    {
        var data = await homePage_TopFosterCenters.ToListAsync();
        var results = data.Select(e => new FosterCenter
        {
            Id = e.Id.ToString(),
            Name = e.Name,
            Address = e.Address,
            Logo = e.Logo,
            Rating = e.Rating,
            CreatedOn = e.CreatedOn,
            IsUserFollowing = e.IsUserFollowing
        }).ToList();
        return new List<FosterCenter>(results);
    }

    public async Task<IEnumerable<Event>> GetTopEventsAsync()
    {
        var data = await homePage_Carousels.ToListAsync();
        var results = data.Select(e => new Event
        {
            Title = e.Title,
            Description = e.Description,
            Image = e.Image,
            DominantColor = e.DominantColor,
            DateTime = e.EventDate
        }).ToList();
        return new List<Event>(results);
    }

    public Task<IEnumerable<NewAdoption>> GetNewAdoptionsAsync()
    {
        throw new NotImplementedException();
    }
    #endregion
}
