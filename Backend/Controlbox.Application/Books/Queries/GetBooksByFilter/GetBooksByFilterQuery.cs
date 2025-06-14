// <copyright file="GetBooksByFilterQuery.cs" company="Controlbox">
// Copyright (c) Controlbox. All rights reserved.
// </copyright>

namespace Controlbox.Application.Books.Queries.GetBooksByFilter
{
    using System.Collections.Generic;
    using Controlbox.Application.Books.Dtos;
    using MediatR;

    /// <summary>
    /// Query to get books with filters.
    /// </summary>
    public class GetBooksByFilterQuery : IRequest<List<BookDto>>
    {
        /// <summary>
        /// Gets or sets the title filter.
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// Gets or sets the author filter.
        /// </summary>
        public string? Author { get; set; }

        /// <summary>
        /// Gets or sets the category filter.
        /// </summary>
        public string? Category { get; set; }
    }
}
