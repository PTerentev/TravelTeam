using System;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using MediatR;
using TravelTeam.UseCases.Common;

namespace TravelTeam.UseCases.Tour.CreateTour
{
    /// <summary>
    /// Create tour command.
    /// </summary>
    public class CreateTourCommand : IRequest<IdResult<int>>
    {
        /// <summary>
        /// Destination location.
        /// </summary>
        public string DestinationLocation { get; set; }

        /// <summary>
        /// Gathering place.
        /// </summary>
        public string GatheringPlace { get; set; }

        /// <summary>
        /// Travel start date.
        /// </summary>
        [Required]
        public DateTime Date { get; set; }

        /// <summary>
        /// Title.
        /// </summary>
        [Required]
        public string Title { get; set; }

        /// <summary>
        /// Description.
        /// </summary>
        [Required]
        public string Description { get; set; }

        /// <summary>
        /// Movement type ID.
        /// </summary>
        [Required]
        public string MovementType { get; set; }

        /// <summary>
        /// Creator user ID.
        /// Do not need to set this property.
        /// </summary>
        public string CreatorUserId { get; set; }
    }
}
