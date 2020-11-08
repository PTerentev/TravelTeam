using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TravelTeam.Abstractions.Data;
using TravelTeam.Domain.Entities;

namespace TravelTeam.DataAccess
{
    /// <summary>
    /// Application database context.
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            Database.EnsureCreated();
        }

        /// <inheritdoc/>
        public DbSet<Tour> Tours { get; private set; }

        /// <inheritdoc/>
        public DbSet<TourParticipant> TourParticipants { get; private set; }

        /// <inheritdoc/>
        public DbSet<MovementType> MovementTypes { get; private set; }
    }
}
