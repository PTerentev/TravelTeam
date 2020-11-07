using System;
using Microsoft.AspNetCore.Identity;

namespace TravelTeam.Domain.Entities
{
    /// <summary>
    /// User with additional information.
    /// </summary>
    public class ApplicationUser : IdentityUser
    {
        public DateTime DateOfBirth { get; set; }

        public string AvatarUrl { get; set; }

        public string About { get; set; }
    }
}
