// <copyright file="CreateReviewCommand.cs" company="Controlbox">
// Copyright (c) Controlbox. All rights reserved.
// </copyright>

namespace Controlbox.Application.Reviews.Commands.CreateReview
{
    using MediatR;

    /// <summary>
    /// Command to create a new review.
    /// </summary>
    public class CreateReviewCommand : IRequest<int>
    {
        /// <summary>
        /// Gets or sets the review rating.
        /// </summary>
        public int Rating { get; set; }

        /// <summary>
        /// Gets or sets the review comment.
        /// </summary>
        public string Comment { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the book ID.
        /// </summary>
        public int BookId { get; set; }

        /// <summary>
        /// Gets or sets the user ID.
        /// </summary>
        public int UserId { get; set; }
    }
}
