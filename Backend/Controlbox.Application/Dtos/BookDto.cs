// <copyright file="BookDto.cs" company="Controlbox">
// Copyright (c) Controlbox. All rights reserved.
// </copyright>

namespace Controlbox.Application.Books.Dtos
{
    using System.Collections.Generic;

    /// <summary>
    /// Data transfer object for a book.
    /// </summary>
    public class BookDto
    {
        /// <summary>
        /// Gets or sets book id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets book title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets book author.
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Gets or sets book description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets book category name.
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Gets or sets the book image URL or path.
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        /// Gets or sets list of reviews.
        /// </summary>
        public List<ReviewDto> Reviews { get; set; } = new List<ReviewDto>();
    }
}
