// <copyright file="LoginUserHandler.cs" company="Controlbox">
// Copyright (c) Controlbox. All rights reserved.
// </copyright>

namespace Controlbox.Application.Users.Commands.LoginUser
{
    using System.Threading;
    using System.Threading.Tasks;
    using Controlbox.Application.Common.Interfaces;
    using MediatR;

    /// <summary>
    /// Handles the login user command and returns a JWT token.
    /// </summary>
    public class LoginUserHandler : IRequestHandler<LoginUserCommand, string?>
    {
        private readonly IUserRepository userRepository;
        private readonly IJwtService jwtService;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginUserHandler"/> class.
        /// </summary>
        /// <param name="userRepository">The user repository.</param>
        /// <param name="jwtService">The JWT service.</param>
        public LoginUserHandler(
            IUserRepository userRepository,
            IJwtService jwtService)
        {
            this.userRepository = userRepository;
            this.jwtService = jwtService;
        }

        /// <summary>
        /// Handles the login user command.
        /// </summary>
        /// <param name="request">The login user command.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The JWT token or null if login fails.</returns>
        public async Task<string?> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = await this.userRepository.GetUserByEmailAsync(request.Email);

            if (user == null)
            {
                return null;
            }

            var isValid = await this.userRepository.ValidateUserAsync(request.Email, request.Password);

            if (!isValid)
            {
                return null;
            }

            return this.jwtService.GenerateToken(user.Id, user.Email, user.Name, user.ProfilePicture);
        }
    }
}
