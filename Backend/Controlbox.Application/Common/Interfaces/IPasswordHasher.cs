// <copyright file="IPasswordHasher.cs" company="Controlbox">
// Copyright (c) Controlbox. All rights reserved.
// </copyright>

namespace Controlbox.Application.Common.Interfaces
{
    /// <summary>
    /// Interface for password hashing and verification.
    /// </summary>
    public interface IPasswordHasher
    {
        /// <summary>
        /// Hashes a plain text password.
        /// </summary>
        /// <param name="password">The password to hash.</param>
        /// <returns>The hashed password.</returns>
        string Hash(string password);

        /// <summary>
        /// Verifies if a plain password matches the hashed password.
        /// </summary>
        /// <param name="password">The plain password.</param>
        /// <param name="hashedPassword">The hashed password.</param>
        /// <returns>True if match; otherwise, false.</returns>
        bool Check(string password, string hashedPassword);
    }
}
