using System;
using System.Collections.Generic;
using System.Drawing;
using TravelTeam.Domain.Entities;

namespace TravelTeam.UseCases.Common
{
    public class TourDto
    {
        public int Id { get; set; }

        public PointF DestinationLocation { get; set; }

        public PointF GatheringPlace { get; set; }

        public DateTime Date { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public MovementType MovementType { get; set; }

        public UserDto CreatorUser { get; set; }

        public IEnumerable<string> TourParticipantsIds { get; set; }
    }
}
