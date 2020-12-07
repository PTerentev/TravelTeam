using System;
using System.Collections.Generic;
using System.Drawing;

namespace TravelTeam.Domain.Entities
{
    /// <summary>
    /// Tour entity.
    /// </summary>
    public class Tour
    {
        /// <summary>
        /// Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Destination location.
        /// </summary>
        public string DestinationLocation { get; set; }

        /// <summary>
        /// Gathering place.
        /// </summary>
        public string GatheringPlace { get; set; }

        /// <summary>
        /// Date.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Created date.
        /// </summary>
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Movement type.
        /// </summary>
        public string MovementType { get; set; }

        /// <summary>
        /// Creator user.
        /// </summary>
        public virtual ApplicationUser CreatorUser { get; set; }

        /// <summary>
        /// Creator user id.
        /// </summary>
        public string CreatorUserId { get; set; }

        /// <summary>
        /// Tour participants.
        /// </summary>
        public virtual ICollection<TourParticipant> TourParticipants { get; set; }
    }
}
