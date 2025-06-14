// <copyright file="LoginUserDto.cs" company="Controlbox">
// Copyright (c) Controlbox. All rights reserved.
// </copyright>

namespace Controlbox.Application.Users.Dtos
{
    /// <summary>
    /// Data transfer object for login user.
    /// </summary>
    public class LoginUserDto
    {
        /// <summary>
        /// Gets or sets user email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets user password.
        /// </summary>
        public string Password { get; set; }
    }
}
