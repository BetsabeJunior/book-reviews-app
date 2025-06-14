// <copyright file="GetBookByIdQuery.cs" company="Controlbox">
// Copyright (c) Controlbox. All rights reserved.
// </copyright>

namespace Controlbox.Application.Books.Queries.GetBookById
{
    using Controlbox.Application.Books.Dtos;
    using MediatR;

    /// <summary>
    /// Query to get one book by ID.
    /// </summary>
    public class GetBookByIdQuery : IRequest<BookDto>
    {
        /// <summary>
        /// Gets or sets the book ID.
        /// </summary>
        public int Id { get; set; }
    }
}
