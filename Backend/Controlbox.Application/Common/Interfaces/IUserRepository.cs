// <copyright file="IUserRepository.cs" company="Controlbox">
// Copyright (c) Controlbox. All rights reserved.
// </copyright>

namespace Controlbox.Application.Common.Interfaces
{
    using System.Threading.Tasks;
    using Controlbox.Domain.Entities;

    /// <summary>
    /// Interface for user data actions.
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Adds a new user.
        /// </summary>
        /// <param name="user">The user to add.</param>
        /// <returns>The added user.</returns>
        Task<User> AddUserAsync(User user);

        /// <summary>
        /// Finds a user by email.
        /// </summary>
        /// <param name="email">The email to search.</param>
        /// <returns>The found user or null.</returns>
        Task<User> GetUserByEmailAsync(string email);

        /// <summary>
        /// Validates the user email and password.
        /// </summary>
        /// <param name="email">The user email.</param>
        /// <param name="plainPassword">The plain password to check.</param>
        /// <returns>True if credentials are correct; otherwise, false.</returns>
        Task<bool> ValidateUserAsync(string email, string plainPassword);

        /// <summary>
        /// Gets a user by ID.
        /// </summary>
        /// <param name="id">The user ID.</param>
        /// <returns>The user or null if not found.</returns>
        Task<User?> GetUserByIdAsync(int id);
    }
}
