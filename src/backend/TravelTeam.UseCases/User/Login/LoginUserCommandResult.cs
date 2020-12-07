namespace TravelTeam.UseCases.User.Login
{
    /// <summary>
    /// Login user command result.
    /// </summary>
    public class LoginUserCommandResult
    {
        /// <summary>
        /// Logged user id (if success).
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// New token.
        /// </summary>
        public string Token { get; set; }
    }
}
