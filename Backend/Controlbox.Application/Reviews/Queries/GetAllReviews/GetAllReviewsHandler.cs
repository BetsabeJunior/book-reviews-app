// <copyright file="GetAllReviewsHandler.cs" company="Controlbox">
// Copyright (c) Controlbox. All rights reserved.
// </copyright>

namespace Controlbox.Application.Reviews.Queries.GetAllReviews
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Controlbox.Application.Common.Interfaces;
    using Controlbox.Domain.Entities;
    using MediatR;

    /// <summary>
    /// Handles the get all reviews query.
    /// </summary>
    public class GetAllReviewsHandler : IRequestHandler<GetAllReviewsQuery, List<Review>>
    {
        private readonly IReviewRepository reviewRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllReviewsHandler"/> class.
        /// </summary>
        /// <param name="reviewRepository">The review repository.</param>
        public GetAllReviewsHandler(IReviewRepository reviewRepository)
        {
            this.reviewRepository = reviewRepository;
        }

        /// <inheritdoc/>
        public async Task<List<Review>> Handle(GetAllReviewsQuery request, CancellationToken cancellationToken)
        {
            return await this.reviewRepository.GetAllReviewsAsync();
        }
    }
}
