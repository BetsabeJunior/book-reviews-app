// <copyright file="CurrentUserService.cs" company="Controlbox">
// Copyright (c) Controlbox. All rights reserved.
// </copyright>

namespace Controlbox.Infrastructure.Services
{
    using System.Security.Claims;
    using Controlbox.Application.Common.Interfaces;
    using Microsoft.AspNetCore.Http;

    /// <summary>
    /// This class gets current user info from the JWT token.
    /// </summary>
    public class CurrentUserService : ICurrentUserService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CurrentUserService"/> class.
        /// </summary>
        /// <param name="httpContextAccessor">HTTP context accessor.</param>
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            string? userIdClaim = httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (!string.IsNullOrEmpty(userIdClaim) && int.TryParse(userIdClaim, out int id))
            {
                this.UserId = id;
            }
        }

        /// <inheritdoc/>
        public int UserId { get; }
    }
}
