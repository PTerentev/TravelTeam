using System;
using System.Collections.Generic;
using System.Drawing;
using TravelTeam.Domain.Entities;

namespace TravelTeam.UseCases.Tour
{
    public class TourInfoDto
    {
        public int Id { get; set; }

        public PointF DestinationLocation { get; set; }

        public PointF GatheringPlace { get; set; }

        public DateTime Date { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public MovementType MovementType { get; set; }

        public ApplicationUser CreatorUser { get; set; }

        public ICollection<TourParticipant> TourParticipants { get; set; }
    }
}
