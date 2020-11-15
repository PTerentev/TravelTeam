using System;

namespace TravelTeam.UseCases.Common
{
    /// <summary>
    /// UserDto.
    /// </summary>
    public class UserDto
    {
        public DateTime DateOfBirth { get; set; }

        public string AvatarUrl { get; set; }

        public string About { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }
    }
}
