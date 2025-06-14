// <copyright file="GetUserProfileHandler.cs" company="Controlbox">
// Copyright (c) Controlbox. All rights reserved.
// </copyright>

namespace Controlbox.Application.Users.Queries.GetUserProfile
{
    using System.Threading;
    using System.Threading.Tasks;
    using Controlbox.Application.Common.Interfaces;
    using MediatR;

    /// <summary>
    /// Handles the get user profile query.
    /// </summary>
    public class GetUserProfileHandler : IRequestHandler<GetUserProfileQuery, UserProfileResponse>
    {
        private readonly IUserRepository userRepository;
        private readonly ICurrentUserService currentUserService;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetUserProfileHandler"/> class.
        /// </summary>
        /// <param name="userRepository">The user repository.</param>
        /// <param name="currentUserService">The current user service.</param>
        public GetUserProfileHandler(
            IUserRepository userRepository,
            ICurrentUserService currentUserService)
        {
            this.userRepository = userRepository;
            this.currentUserService = currentUserService;
        }

        /// <inheritdoc/>
        public async Task<UserProfileResponse> Handle(
            GetUserProfileQuery request,
            CancellationToken cancellationToken)
        {
            int userId = this.currentUserService.UserId;

            var user = await this.userRepository.GetUserByIdAsync(userId);

            if (user == null)
            {
                return null!;
            }

            return new UserProfileResponse
            {
                Name = user.Name,
                Email = user.Email,
                ProfilePicture = user.ProfilePicture,
            };
        }
    }
}
