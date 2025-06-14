// <copyright file="UserProfileResponse.cs" company="Controlbox">
// Copyright (c) Controlbox. All rights reserved.
// </copyright>

namespace Controlbox.Application.Users.Queries.GetUserProfile
{
    /// <summary>
    /// Represents the user profile response data.
    /// </summary>
    public class UserProfileResponse
    {
        /// <summary>
        /// Gets or sets the user's name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the user's email.
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the user's profile picture.
        /// </summary>
        public string? ProfilePicture { get; set; }
    }
}
