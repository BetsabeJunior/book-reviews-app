// <copyright file="LoginUserCommand.cs" company="Controlbox">
// Copyright (c) Controlbox. All rights reserved.
// </copyright>

namespace Controlbox.Application.Users.Commands.LoginUser
{
    using MediatR;

    /// <summary>
    /// Command to login user and return a JWT token.
    /// </summary>
    public class LoginUserCommand : IRequest<string?>
    {
        /// <summary>
        /// Gets or sets the email of the user.
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the password of the user.
        /// </summary>
        public string Password { get; set; } = string.Empty;
    }
}
