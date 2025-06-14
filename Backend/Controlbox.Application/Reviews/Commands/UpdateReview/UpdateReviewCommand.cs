// <copyright file="UpdateReviewCommand.cs" company="Controlbox">
// Copyright (c) Controlbox. All rights reserved.
// </copyright>

namespace Controlbox.Application.Reviews.Commands.UpdateReview
{
    using MediatR;

    /// <summary>
    /// Command to update a review.
    /// </summary>
    public class UpdateReviewCommand : IRequest<bool>
    {
        /// <summary>
        /// Gets or sets the review id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the new comment.
        /// </summary>
        public string Comment { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the new rating.
        /// </summary>
        public int Rating { get; set; }
    }
}
