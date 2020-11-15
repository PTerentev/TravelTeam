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
        public int Id { get; set; }

        public PointF DestinationLocation { get; set; }

        public PointF GatheringPlace { get; set; }

        public DateTime Date { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public string Title { get; set; }

        public string Description { get; set; }

        public MovementType MovementType { get; set; }

        public int MovementTypeId { get; set; }

        public ApplicationUser CreatorUser { get; set; }

        public string CreatorUserId { get; set; }

        public ICollection<TourParticipant> TourParticipants { get; set; }
    }
}
