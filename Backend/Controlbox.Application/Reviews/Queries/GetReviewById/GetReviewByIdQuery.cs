// <copyright file="GetReviewByIdQuery.cs" company="Controlbox">
// Copyright (c) Controlbox. All rights reserved.
// </copyright>

namespace Controlbox.Application.Reviews.Queries.GetReviewById
{
    using Controlbox.Domain.Entities;
    using MediatR;

    /// <summary>
    /// Query to get one review by id.
    /// </summary>
    public class GetReviewByIdQuery : IRequest<Review>
    {
        /// <summary>
        /// Gets or sets the review id.
        /// </summary>
        public int Id { get; set; }
    }
}
