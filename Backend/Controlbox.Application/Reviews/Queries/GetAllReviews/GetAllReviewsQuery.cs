// <copyright file="GetAllReviewsQuery.cs" company="Controlbox">
// Copyright (c) Controlbox. All rights reserved.
// </copyright>

namespace Controlbox.Application.Reviews.Queries.GetAllReviews
{
    using System.Collections.Generic;
    using Controlbox.Domain.Entities;
    using MediatR;

    /// <summary>
    /// Query to get all reviews.
    /// </summary>
    public class GetAllReviewsQuery : IRequest<List<Review>>
    {
    }
}
