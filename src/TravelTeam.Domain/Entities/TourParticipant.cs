namespace TravelTeam.Domain.Entities
{
    /// <summary>
    /// Tour participants.
    /// </summary>
    public class TourParticipant
    {
        public int Id { get; set; }

        public Tour Tour { get; set; }

        public int TourId { get; set; }

        public ApplicationUser User { get; set; }

        public string UserId { get; set; }
    }
}
