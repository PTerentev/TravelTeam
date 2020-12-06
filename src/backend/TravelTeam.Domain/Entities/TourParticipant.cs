namespace TravelTeam.Domain.Entities
{
    /// <summary>
    /// Tour participants.
    /// </summary>
    public class TourParticipant
    {
        /// <summary>
        /// Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Tour.
        /// </summary>
        public virtual Tour Tour { get; set; }

        /// <summary>
        /// Tour Id.
        /// </summary>
        public int TourId { get; set; }

        /// <summary>
        /// User.
        /// </summary>
        public virtual ApplicationUser User { get; set; }

        /// <summary>
        /// User Id.
        /// </summary>
        public string UserId { get; set; }
    }
}
