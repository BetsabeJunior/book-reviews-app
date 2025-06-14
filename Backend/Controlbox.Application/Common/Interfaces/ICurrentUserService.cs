// <copyright file="ICurrentUserService.cs" company="Controlbox">
// Copyright (c) Controlbox. All rights reserved.
// </copyright>

namespace Controlbox.Application.Common.Interfaces
{
    /// <summary>
    /// This interface gets current user info from token.
    /// </summary>
    public interface ICurrentUserService
    {
        /// <summary>
        /// Gets the current user ID.
        /// </summary>
        int UserId { get; }
    }
}
