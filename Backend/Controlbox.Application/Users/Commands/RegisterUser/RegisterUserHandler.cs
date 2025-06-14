// <copyright file="RegisterUserHandler.cs" company="Controlbox">
// Copyright (c) Controlbox. All rights reserved.
// </copyright>

namespace Controlbox.Application.Users.Commands.RegisterUser
{
    using System.Threading;
    using System.Threading.Tasks;
    using BCrypt.Net;
    using Controlbox.Application.Common.Interfaces;
    using Controlbox.Domain.Entities;
    using MediatR;

    /// <summary>
    /// Handles the register user command.
    /// </summary>
    public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, int>
    {
        /// <summary>
        /// The user repository instance.
        /// </summary>
        private readonly IUserRepository userRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="RegisterUserHandler"/> class.
        /// </summary>
        /// <param name="userRepository">The user repository.</param>
        public RegisterUserHandler(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        /// <summary>
        /// Handles the user registration logic.
        /// </summary>
        /// <param name="request">The registration command.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The new user ID.</returns>
        public async Task<int> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                Name = request.Name,
                Email = request.Email,
                Password = BCrypt.HashPassword(request.Password),
                ProfilePicture = request.ProfilePicture,
            };

            var result = await this.userRepository.AddUserAsync(user);

            return result?.Id ?? 0;
        }
    }
}
