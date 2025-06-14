// <copyright file="CreateBookResponse.cs" company="Controlbox">
// Copyright (c) Controlbox. All rights reserved.
// </copyright>

namespace Controlbox.Application.Books.Commands.CreateBook
{
    /// <summary>
    /// This is the response for creating a book.
    /// </summary>
    public class CreateBookResponse
    {
        /// <summary>
        /// Gets or sets the new book id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the book title.
        /// </summary>
        public string Title { get; set; } = string.Empty;
    }
}
