// <copyright file="User.cs" company="Controlbox">
// Copyright (c) Controlbox. All rights reserved.
// </copyright>

namespace Controlbox.Domain.Entities
{
    /// <summary>
    /// Represents a person who uses the app.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Gets or sets the user ID.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the user name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the user email.
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the user password (hashed).
        /// </summary>
        public string Password { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the user photo (optional).
        /// </summary>
        public string? ProfilePicture { get; set; }

        /// <summary>
        /// Gets or sets the creation date.
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Gets or sets the reviews made by the user.
        /// </summary>
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}
