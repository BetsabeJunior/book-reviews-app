// <copyright file="CreateBookDto.cs" company="Controlbox">
// Copyright (c) Controlbox. All rights reserved.
// </copyright>

namespace Controlbox.Application.Books.Dtos
{
    /// <summary>
    /// Data transfer object for a created book.
    /// </summary>
    public class CreateBookDto
    {
        /// <summary>
        /// Gets or sets the book id.
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
        /// Gets or sets the book description.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the book category id.
        /// </summary>
        public int? CategoryId { get; set; }

        /// <summary>
        /// Gets or sets the book image URL or path.
        /// </summary>
        public string ImageUrl { get; set; }
    }
}
