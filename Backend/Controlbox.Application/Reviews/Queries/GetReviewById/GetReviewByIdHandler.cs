// <copyright file="GetReviewByIdHandler.cs" company="Controlbox">
// Copyright (c) Controlbox. All rights reserved.
// </copyright>

namespace Controlbox.Application.Reviews.Queries.GetReviewById
{
    using System.Threading;
    using System.Threading.Tasks;
    using Controlbox.Application.Common.Interfaces;
    using Controlbox.Domain.Entities;
    using MediatR;

    /// <summary>
    /// Handler for GetReviewByIdQuery.
    /// </summary>
    public class GetReviewByIdHandler : IRequestHandler<GetReviewByIdQuery, Review>
    {
        private readonly IReviewRepository reviewRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetReviewByIdHandler"/> class.
        /// </summary>
        /// <param name="reviewRepository">The review repository.</param>
        public GetReviewByIdHandler(IReviewRepository reviewRepository)
        {
            this.reviewRepository = reviewRepository;
        }

        /// <inheritdoc/>
        public async Task<Review> Handle(GetReviewByIdQuery request, CancellationToken cancellationToken)
        {
            return await this.reviewRepository.GetReviewByIdAsync(request.Id);
        }
    }
}
