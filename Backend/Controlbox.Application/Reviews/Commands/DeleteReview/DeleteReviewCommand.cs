// <copyright file="DeleteReviewCommand.cs" company="Controlbox">
// Copyright (c) Controlbox. All rights reserved.
// </copyright>

namespace Controlbox.Application.Reviews.Commands.DeleteReview
{
    using MediatR;

    /// <summary>
    /// Command to delete a review.
    /// </summary>
    public class DeleteReviewCommand : IRequest<bool>
    {
        /// <summary>
        /// Gets or sets the review id.
        /// </summary>
        public int Id { get; set; }
    }
}
