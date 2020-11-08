using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TravelTeam.Domain.Entities;

namespace TravelTeam.Abstractions.Data
{
    /// <summary>
    /// Application database context.
    /// </summary>
    public interface IApplicationDbContext
    {
        /// <summary>
        /// Users table.
        /// </summary>
        public DbSet<ApplicationUser> Users { get; }

        /// <summary>
        /// Tours table.
        /// </summary>
        public DbSet<Tour> Tours { get; }

        /// <summary>
        /// Tour participants table.
        /// </summary>
        public DbSet<TourParticipant> TourParticipants { get; }

        /// <summary>
        /// Movement types table.
        /// </summary>
        public DbSet<MovementType> MovementTypes { get; }

        /// <summary>
        /// Save changes in Database.
        /// </summary>
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
