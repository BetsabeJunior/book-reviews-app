// <copyright file="GetAllBooksQuery.cs" company="Controlbox">
// Copyright (c) Controlbox. All rights reserved.
// </copyright>

namespace Controlbox.Application.Books.Queries.GetAllBooks
{
    using System.Collections.Generic;
    using Controlbox.Application.Books.Dtos;
    using MediatR;

    /// <summary>
    /// Query to get all books.
    /// </summary>
    public class GetAllBooksQuery : IRequest<List<BookDto>>
    {
    }
}
