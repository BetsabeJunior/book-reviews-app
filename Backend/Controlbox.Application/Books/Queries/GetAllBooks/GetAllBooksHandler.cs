// <copyright file="GetAllBooksHandler.cs" company="Controlbox">
// Copyright (c) Controlbox. All rights reserved.
// </copyright>

namespace Controlbox.Application.Books.Queries.GetAllBooks
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Controlbox.Application.Books.Dtos;
    using Controlbox.Application.Common.Interfaces;
    using Controlbox.Domain.Entities;
    using MediatR;

    /// <summary>
    /// Handler to get all books.
    /// </summary>
    public class GetAllBooksHandler : IRequestHandler<GetAllBooksQuery, List<BookDto>>
    {
        private readonly IBookRepository bookRepository;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllBooksHandler"/> class.
        /// </summary>
        /// <param name="bookRepository">The book repository.</param>
        /// <param name="mapper">The AutoMapper instance.</param>
        public GetAllBooksHandler(IBookRepository bookRepository, IMapper mapper)
        {
            this.bookRepository = bookRepository;
            this.mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<List<BookDto>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            var books = await this.bookRepository.GetAllBooksAsync();
            return this.mapper.Map<List<BookDto>>(books);
        }
    }
}