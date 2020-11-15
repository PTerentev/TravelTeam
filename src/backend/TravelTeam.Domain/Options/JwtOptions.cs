namespace TravelTeam.Domain.Options
{
    /// <summary>
    /// JWT options.
    /// </summary>
    public class JwtOptions
    {
        /// <summary>
        /// Name of the option.
        /// </summary>
        public const string Name = "JwtOptions";

        /// <summary>
        /// JWT token audience. Specifies the area to use.
        /// </summary>
        public string Audience { get; set; }

        /// <summary>
        /// Secret key that is used to generate JWT token.
        /// </summary>
        public string SecretKey { get; set; }

        /// <summary>
        /// JWT token issuer. String or URL.
        /// </summary>
        public string Issuer { get; set; }

        /// <summary>
        /// Expiration time in seconds.
        /// </summary>
        public int ExpirationTimeSeconds { get; set; }

        /// <summary>
        /// Refresh token expire in days.
        /// </summary>
        public int RefreshTokenExpireDays { get; set; }
    }
}
