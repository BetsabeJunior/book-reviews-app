// <copyright file="UpdateBookCommand.cs" company="Controlbox">
// Copyright (c) Controlbox. All rights reserved.
// </copyright>

namespace Controlbox.Application.Books.Commands.UpdateBook
{
    using MediatR;

    /// <summary>
    /// Command to update a book.
    /// </summary>
    public class UpdateBookCommand : IRequest<UpdateBookResponse>
    {
        /// <summary>
        /// Gets or sets book id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets book title.
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets book author.
        /// </summary>
        public string Author { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets book description.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets book category id.
        /// </summary>
        public int? CategoryId { get; set; }
    }
}
