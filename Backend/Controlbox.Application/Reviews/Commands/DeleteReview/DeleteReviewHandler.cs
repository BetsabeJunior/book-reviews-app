// <copyright file="DeleteReviewHandler.cs" company="Controlbox">
// Copyright (c) Controlbox. All rights reserved.
// </copyright>

namespace Controlbox.Application.Reviews.Commands.DeleteReview
{
    using System.Threading;
    using System.Threading.Tasks;
    using Controlbox.Application.Common.Interfaces;
    using MediatR;

    /// <summary>
    /// Handles the delete review command.
    /// </summary>
    public class DeleteReviewHandler : IRequestHandler<DeleteReviewCommand, bool>
    {
        private readonly IReviewRepository reviewRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteReviewHandler"/> class.
        /// </summary>
        /// <param name="reviewRepository">The review repository.</param>
        public DeleteReviewHandler(IReviewRepository reviewRepository)
        {
            this.reviewRepository = reviewRepository;
        }

        /// <inheritdoc/>
        public async Task<bool> Handle(DeleteReviewCommand request, CancellationToken cancellationToken)
        {
            return await this.reviewRepository.DeleteReviewAsync(request.Id);
        }
    }
}
