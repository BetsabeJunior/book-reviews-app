// <copyright file="UpdateUserCommand.cs" company="Controlbox">
// Copyright (c) Controlbox. All rights reserved.
// </copyright>

namespace Controlbox.Application.Users.Commands.UpdateUser
{
    using Controlbox.Application.Common.DTOs;
    using MediatR;

    /// <summary>
    /// Command to update a user profile.
    /// </summary>
    public class UpdateUserCommand : IRequest<AuthResponseDto>
    {
        /// <summary>
        /// Gets or sets the user ID.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the user name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the user email.
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the profile picture URL.
        /// </summary>
        public string ProfilePicture { get; set; } = string.Empty;
    }
}
