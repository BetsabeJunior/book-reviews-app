// <copyright file="UpdateReviewHandler.cs" company="Controlbox">
// Copyright (c) Controlbox. All rights reserved.
// </copyright>

namespace Controlbox.Application.Reviews.Commands.UpdateReview
{
    using System.Threading;
    using System.Threading.Tasks;
    using Controlbox.Application.Common.Interfaces;
    using MediatR;

    /// <summary>
    /// Handles the update review command.
    /// </summary>
    public class UpdateReviewHandler : IRequestHandler<UpdateReviewCommand, bool>
    {
        private readonly IReviewRepository reviewRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateReviewHandler"/> class.
        /// </summary>
        /// <param name="reviewRepository">The review repository.</param>
        public UpdateReviewHandler(IReviewRepository reviewRepository)
        {
            this.reviewRepository = reviewRepository;
        }

        /// <inheritdoc/>
        public async Task<bool> Handle(UpdateReviewCommand request, CancellationToken cancellationToken)
        {
            return await this.reviewRepository.UpdateReviewAsync(
                request.Id,
                request.Comment,
                request.Rating);
        }
    }
}
