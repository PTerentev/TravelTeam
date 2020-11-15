namespace TravelTeam.Domain.Entities
{
    /// <summary>
    /// Movement type of traveling.
    /// Car, boat for example.
    /// </summary>
    public class MovementType
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
