// <copyright file="GetReviewsByBookIdQuery.cs" company="Controlbox">
// Copyright (c) Controlbox. All rights reserved.
// </copyright>

namespace Controlbox.Application.Reviews.Queries.GetReviewsByBookId
{
    using System.Collections.Generic;
    using MediatR;

    /// <summary>
    /// Query to get reviews by book id.
    /// </summary>
    public class GetReviewsByBookIdQuery : IRequest<List<ReviewDto>>
    {
        /// <summary>
        /// Gets or sets the book id.
        /// </summary>
        public int BookId { get; set; }
    }
}
