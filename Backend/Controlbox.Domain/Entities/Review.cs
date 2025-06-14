// <copyright file="Review.cs" company="Controlbox">
// Copyright (c) Controlbox. All rights reserved.
// </copyright>

namespace Controlbox.Domain.Entities
{
    /// <summary>
    /// Represents a user review for a book.
    /// </summary>
    public class Review
    {
        /// <summary>
        /// Gets or sets the review ID.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the review comment.
        /// </summary>
        public string Comment { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the rating from 1 to 5.
        /// </summary>
        public int Rating { get; set; }

        /// <summary>
        /// Gets or sets the review date.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the user ID.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the user who made the review.
        /// </summary>
        public User? User { get; set; }

        /// <summary>
        /// Gets or sets the book ID.
        /// </summary>
        public int BookId { get; set; }

        /// <summary>
        /// Gets or sets the book reviewed.
        /// </summary>
        public Book? Book { get; set; }
    }
}
