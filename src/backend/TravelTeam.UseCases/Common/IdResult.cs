namespace TravelTeam.UseCases.Common
{
    /// <summary>
    /// ID result.
    /// </summary>
    public class IdResult<TId>
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public IdResult(TId id)
        {
            Id = id;
        }

        /// <summary>
        /// ID.
        /// </summary>
        public TId Id { get; internal set; }
    }
}
