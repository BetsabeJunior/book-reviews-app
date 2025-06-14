// <copyright file="DeleteBookCommand.cs" company="Controlbox">
// Copyright (c) Controlbox. All rights reserved.
// </copyright>

namespace Controlbox.Application.Books.Commands.DeleteBook
{
    using MediatR;

    /// <summary>
    /// Command to delete a book by ID.
    /// </summary>
    public class DeleteBookCommand : IRequest<bool>
    {
        /// <summary>
        /// Gets or sets the book ID to delete.
        /// </summary>
        public int Id { get; set; }
    }
}
