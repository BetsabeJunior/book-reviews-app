// <copyright file="Book.cs" company="Controlbox">
// Copyright (c) Controlbox. All rights reserved.
// </copyright>

namespace Controlbox.Domain.Entities
{
    /// <summary>
    /// Represents a book with title, author, and summary.
    /// </summary>
    public class Book
    {
        /// <summary>
        /// Gets or sets the book ID.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the book title.
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the book author.
        /// </summary>
        public string Author { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the book summary.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the book image URL (optional).
        /// </summary>
        public string? ImageUrl { get; set; }

        /// <summary>
        /// Gets or sets the book creation date.
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Gets or sets the category ID.
        /// </summary>
        public int? CategoryId { get; set; }

        /// <summary>
        /// Gets or sets the category of the book.
        /// </summary>
        public Category? Category { get; set; }

        /// <summary>
        /// Gets or sets the reviews of the book.
        /// </summary>
        public ICollection<Review>? Reviews { get; set; }
    }
}
