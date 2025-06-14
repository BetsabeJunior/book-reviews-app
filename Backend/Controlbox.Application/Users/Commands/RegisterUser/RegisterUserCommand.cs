// <copyright file="RegisterUserCommand.cs" company="Controlbox">
// Copyright (c) Controlbox. All rights reserved.
// </copyright>

namespace Controlbox.Application.Users.Commands.RegisterUser
{
    using MediatR;

    /// <summary>
    /// This class is the input to register a user.
    /// </summary>
    public class RegisterUserCommand : IRequest<int>
    {
        /// <summary>
        /// Gets or sets the user name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the user email.
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the user password.
        /// </summary>
        public string Password { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the profile picture. This can be null.
        /// </summary>
        public string? ProfilePicture { get; set; }
    }
}
