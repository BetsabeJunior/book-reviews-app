// <copyright file="AuthResponseDto.cs" company="Controlbox">
// Copyright (c) Controlbox. All rights reserved.
// </copyright>

namespace Controlbox.Application.Common.DTOs
{
    /// <summary>
    /// Token and user data for authentication.
    /// </summary>
    public class AuthResponseDto
    {
        /// <summary>
        /// Gets or sets the JWT token.
        /// </summary>
        public string Token { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the user data.
        /// </summary>
        public UserDto User { get; set; } = null!;
    }
}
