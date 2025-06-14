// <copyright file="GetBookByIdHandler.cs" company="Controlbox">
// Copyright (c) Controlbox. All rights reserved.
// </copyright>

namespace Controlbox.Application.Books.Queries.GetBookById
{
    using System.Threading;
    using System.Threading.Tasks;
    using Controlbox.Application.Books.Dtos;
    using Controlbox.Application.Common.Interfaces;
    using Controlbox.Domain.Entities;
    using MediatR;

    /// <summary>
    /// Handler to get one book by ID.
    /// </summary>
    public class GetBookByIdHandler : IRequestHandler<GetBookByIdQuery, BookDto>
    {
        private readonly IBookRepository bookRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetBookByIdHandler"/> class.
        /// </summary>
        /// <param name="bookRepository">The book repository.</param>
        public GetBookByIdHandler(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        /// <inheritdoc/>
        public async Task<BookDto> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var book = await this.bookRepository.GetBookWithReviewsAsync(request.Id);

            if (book == null)
            {
                return null;
            }

            return new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Description = book.Description,
                Category = book.Category?.Name,
                ImageUrl = book.ImageUrl,
                Reviews = book.Reviews?.Select(r => new ReviewDto
                {
                    Id = r.Id,
                    Comment = r.Comment,
                    Rating = r.Rating,
                    UserId = r.User?.Id.ToString() ?? string.Empty,
                    Username = r.User?.Name ?? "Unknown",
                }).ToList(),
            };
        }

    }
}
