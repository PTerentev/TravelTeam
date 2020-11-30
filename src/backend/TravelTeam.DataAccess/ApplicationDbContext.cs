using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TravelTeam.Domain.Entities;

namespace TravelTeam.DataAccess
{
    /// <summary>
    /// Application database context.
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            Database.EnsureCreated();
        }

        /// <summary>
        /// Tours table.
        /// </summary>
        public DbSet<Tour> Tours { get; private set; }

        /// <summary>
        /// Tour participants table.
        /// </summary>
        public DbSet<TourParticipant> TourParticipants { get; private set; }
    }
}
