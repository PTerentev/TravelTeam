using System;
using System.Collections.Generic;

namespace TravelTeam.UseCases.Common
{
    /// <summary>
    /// Tour DTO.
    /// </summary>
    public class TourDto
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
        public UserDto CreatorUser { get; set; }

        /// <summary>
        /// Tour participants ids.
        /// </summary>
        public IEnumerable<string> TourParticipantsIds { get; set; }
    }
}
