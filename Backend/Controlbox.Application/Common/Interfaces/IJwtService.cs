// <copyright file="IJwtService.cs" company="Controlbox">
// Copyright (c) Controlbox. All rights reserved.
// </copyright>

namespace Controlbox.Application.Common.Interfaces
{
    /// <summary>
    /// Interface for JWT token service.
    /// </summary>
    public interface IJwtService
    {
        /// <summary>
        /// Generates a JWT token.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <param name="email">The user email.</param>
        /// <param name="name">The user name.</param>
        /// <returns>The JWT token string.</returns>
        string GenerateToken(int userId, string email, string name, string profilePicture);
    }
}
