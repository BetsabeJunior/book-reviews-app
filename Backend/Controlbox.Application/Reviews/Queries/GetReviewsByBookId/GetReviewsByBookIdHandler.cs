// <copyright file="GetReviewsByBookIdHandler.cs" company="Controlbox">
// Copyright (c) Controlbox. All rights reserved.
// </copyright>

namespace Controlbox.Application.Reviews.Queries.GetReviewsByBookId
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Controlbox.Application.Common.Interfaces;
    using MediatR;

    /// <summary>
    /// Handles get reviews by book id query.
    /// </summary>
    public class GetReviewsByBookIdHandler : IRequestHandler<GetReviewsByBookIdQuery, List<ReviewDto>>
    {
        private readonly IReviewRepository reviewRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetReviewsByBookIdHandler"/> class.
        /// </summary>
        /// <param name="reviewRepository">The review repository.</param>
        public GetReviewsByBookIdHandler(IReviewRepository reviewRepository)
        {
            this.reviewRepository = reviewRepository;
        }

        /// <inheritdoc/>
        public async Task<List<ReviewDto>> Handle(GetReviewsByBookIdQuery request, CancellationToken cancellationToken)
        {
            var reviews = await this.reviewRepository.GetReviewsByBookIdAsync(request.BookId);

            return reviews.Select(r => new ReviewDto
            {
                Id = r.Id,
                Comment = r.Comment,
                Rating = r.Rating,
                BookId = r.BookId,
                UserId = r.UserId,
            }).ToList();
        }
    }
}
