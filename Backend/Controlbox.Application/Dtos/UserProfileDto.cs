// <copyright file="UserProfileDto.cs" company="Controlbox">
// Copyright (c) Controlbox. All rights reserved.
// </copyright>

namespace Controlbox.Application.Users.Queries.GetUserProfile
{
    /// <summary>
    /// Data transfer object for user profile.
    /// </summary>
    public class UserProfileDto
    {
        /// <summary>
        /// Gets or sets user id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets username.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets profile photo url.
        /// </summary>
        public string? PhotoUrl { get; set; }
    }
}
