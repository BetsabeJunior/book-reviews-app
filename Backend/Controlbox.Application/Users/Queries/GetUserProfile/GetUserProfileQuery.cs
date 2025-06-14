// <copyright file="GetUserProfileQuery.cs" company="Controlbox">
// Copyright (c) Controlbox. All rights reserved.
// </copyright>

namespace Controlbox.Application.Users.Queries.GetUserProfile
{
    using MediatR;

    /// <summary>
    /// This query gets the current user profile data.
    /// </summary>
    public class GetUserProfileQuery : IRequest<UserProfileResponse>
    {
    }
}
