using Microsoft.EntityFrameworkCore;

namespace Petaverse.UWP.LogicProvider.Offline;

public class PetaverseLocalDbContext : DbContext
{

    #region [ CTors ]

    public PetaverseLocalDbContext(DbContextOptions<PetaverseLocalDbContext> options) : base(options)
    {

    }
    #endregion

    #region [ DbSets ]

    public DbSet<HomePage_TopFosterCenters> HomePage_TopFosterCenters { get; set; }
    public DbSet<HomePage_NewAdoptions> HomePage_NewAdoptions { get; set; }
    public DbSet<HomePage_UrgentCases> HomePage_UrgentCases { get; set; }
    public DbSet<HomePage_Carousels> HomePage_Carousels { get; set; }
    #endregion

    #region [ Overrides ]

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Seed();
    }
    #endregion
}