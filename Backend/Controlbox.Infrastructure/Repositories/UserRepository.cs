// <copyright file="UserRepository.cs" company="Controlbox">
// Copyright (c) Controlbox. All rights reserved.
// </copyright>

namespace Controlbox.Infrastructure.Repositories
{
    using System.Threading.Tasks;
    using BCrypt.Net;
    using Controlbox.Application.Common.Interfaces;
    using Controlbox.Domain.Entities;
    using Controlbox.Infrastructure.Data;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Repository for user actions.
    /// </summary>
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class.
        /// </summary>
        /// <param name="context">The application database context.</param>
        public UserRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        /// <inheritdoc/>
        public async Task<User> AddUserAsync(User user)
        {
            this.context.Users.Add(user);
            await this.context.SaveChangesAsync();
            return user;
        }

        /// <inheritdoc/>
        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await this.context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        /// <inheritdoc/>
        /// <inheritdoc/>
        public async Task<bool> ValidateUserAsync(string email, string plainPassword)
        {
            var user = await this.context.Users.FirstOrDefaultAsync(u => u.Email == email);

            if (user == null)
            {
                return false;
            }

            return BCrypt.Verify(plainPassword, user.Password);
        }

        /// <inheritdoc/>
        public async Task<User?> GetUserByIdAsync(int id)
        {
            return await this.context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }
    }
}
