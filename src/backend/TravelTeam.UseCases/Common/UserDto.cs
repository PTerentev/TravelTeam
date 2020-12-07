using System;

namespace TravelTeam.UseCases.Common
{
    /// <summary>
    /// UserDto.
    /// </summary>
    public class UserDto
    {
        /// <summary>
        /// Id.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Date of birth.
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Avatart url.
        /// </summary>
        public string AvatarUrl { get; set; }

        /// <summary>
        /// About.
        /// </summary>
        public string About { get; set; }

        /// <summary>
        /// First name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Phone number.
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Username.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Email.
        /// </summary>
        public string Email { get; set; }
    }
}
