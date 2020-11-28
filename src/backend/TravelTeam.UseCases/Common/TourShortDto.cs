using System;

namespace TravelTeam.UseCases.Common
{
    /// <summary>
    /// Short tour DTO.
    /// </summary>
    public class TourShortDto
    {
        /// <summary>
        /// Id.
        /// </summary>
        public int Id { get; set; }

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
    }
}
