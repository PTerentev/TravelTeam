using System;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using MediatR;

namespace TravelTeam.UseCases.Tour.CreateTour
{
    /// <summary>
    /// Create tour command.
    /// </summary>
    public class CreateTourCommand : IRequest
    {
        public PointF DestinationLocation { get; set; }

        public PointF GatheringPlace { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public int MovementTypeId { get; set; }

        public string CreatorUserId { get; set; }
    }
}
