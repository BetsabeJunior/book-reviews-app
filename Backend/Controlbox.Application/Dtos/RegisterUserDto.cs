// <copyright file="RegisterUserDto.cs" company="Controlbox">
// Copyright (c) Controlbox. All rights reserved.
// </copyright>

namespace Controlbox.Application.Users.Dtos
{
    /// <summary>
    /// Data transfer object for register user.
    /// </summary>
    public class RegisterUserDto
    {
        /// <summary>
        /// Gets or sets user name.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets user email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets user password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets user photo URL.
        /// </summary>
        public string? PhotoUrl { get; set; }
    }
}
