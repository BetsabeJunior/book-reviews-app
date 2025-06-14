// <copyright file="GetBooksByFilterHandler.cs" company="Controlbox">
// Copyright (c) Controlbox. All rights reserved.
// </copyright>

namespace Controlbox.Application.Books.Queries.GetBooksByFilter
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Controlbox.Application.Books.Dtos;
    using Controlbox.Application.Common.Interfaces;
    using MediatR;

    /// <summary>
    /// Handler to get books by filters.
    /// </summary>
    public class GetBooksByFilterHandler : IRequestHandler<GetBooksByFilterQuery, List<BookDto>>
    {
        private readonly IBookRepository bookRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetBooksByFilterHandler"/> class.
        /// </summary>
        /// <param name="bookRepository">The book repository.</param>
        public GetBooksByFilterHandler(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        /// <inheritdoc/>
        public async Task<List<BookDto>> Handle(GetBooksByFilterQuery request, CancellationToken cancellationToken)
        {
            var books = await this.bookRepository.GetAllBooksAsync();

            if (!string.IsNullOrWhiteSpace(request.Title))
            {
                books = books
                    .Where(b => b.Title != null && b.Title
                    .ToLower().Contains(request.Title.ToLower()))
                    .ToList();
            }

            if (!string.IsNullOrWhiteSpace(request.Author))
            {
                books = books
                    .Where(b => b.Author != null && b.Author
                    .ToLower().Contains(request.Author.ToLower()))
                    .ToList();
            }

            if (!string.IsNullOrWhiteSpace(request.Category))
            {
                books = books
                    .Where(b => b.Category != null && b.Category.Name != null &&
                                b.Category.Name.ToLower().Contains(request.Category.ToLower()))
                    .ToList();
            }

            var result = books.Select(b => new BookDto
            {
                Id = b.Id,
                Title = b.Title,
                Author = b.Author,
                Description = b.Description,
                Category = b.Category?.Name,
                ImageUrl = b.ImageUrl,
            }).ToList();

            return result;
        }
    }
}
