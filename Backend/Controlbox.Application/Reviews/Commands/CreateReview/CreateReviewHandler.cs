// <copyright file="CreateReviewHandler.cs" company="Controlbox">
// Copyright (c) Controlbox. All rights reserved.
// </copyright>

namespace Controlbox.Application.Reviews.Commands.CreateReview
{
    using System.Threading;
    using System.Threading.Tasks;
    using Controlbox.Application.Common.Interfaces;
    using Controlbox.Domain.Entities;
    using MediatR;

    /// <summary>
    /// Handles the create review command.
    /// </summary>
    public class CreateReviewHandler : IRequestHandler<CreateReviewCommand, int>
    {
        private readonly IReviewRepository reviewRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateReviewHandler"/> class.
        /// </summary>
        /// <param name="reviewRepository">The review repository.</param>
        public CreateReviewHandler(IReviewRepository reviewRepository)
        {
            this.reviewRepository = reviewRepository;
        }

        /// <inheritdoc/>
        public async Task<int> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
        {
            var review = new Review
            {
                Rating = request.Rating,
                Comment = request.Comment,
                BookId = request.BookId,
                UserId = request.UserId,
            };

            var createdReview = await this.reviewRepository.AddReviewAsync(review);
            return createdReview.Id;
        }
    }
}
