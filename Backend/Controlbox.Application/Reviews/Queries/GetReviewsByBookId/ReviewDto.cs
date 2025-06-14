// <copyright file="ReviewDto.cs" company="Controlbox">
// Copyright (c) Controlbox. All rights reserved.
// </copyright>

namespace Controlbox.Application.Reviews.Queries.GetReviewsByBookId
{
    /// <summary>
    /// Data transfer object for a review.
    /// </summary>
    public class ReviewDto
    {
        /// <summary>
        /// Gets or sets the review id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the comment.
        /// </summary>
        public string Comment { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the rating.
        /// </summary>
        public int Rating { get; set; }

        /// <summary>
        /// Gets or sets the book id.
        /// </summary>
        public int BookId { get; set; }

        /// <summary>
        /// Gets or sets the user id.
        /// </summary>
        public int UserId { get; set; }
    }
}
