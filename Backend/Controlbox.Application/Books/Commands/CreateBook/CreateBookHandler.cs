// <copyright file="CreateBookHandler.cs" company="Controlbox">
// Copyright (c) Controlbox. All rights reserved.
// </copyright>

namespace Controlbox.Application.Books.Commands.CreateBook
{
    using System.Threading;
    using System.Threading.Tasks;
    using Controlbox.Application.Books.Dtos;
    using Controlbox.Application.Common.Interfaces;
    using Controlbox.Domain.Entities;
    using MediatR;

    /// <summary>
    /// This handler processes the create book command.
    /// </summary>
    public class CreateBookHandler : IRequestHandler<CreateBookCommand, CreateBookDto>
    {
        private readonly IBookRepository bookRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateBookHandler"/> class.
        /// </summary>
        /// <param name="bookRepository">The book repository.</param>
        public CreateBookHandler(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        /// <inheritdoc/>
        public async Task<CreateBookDto> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var book = new Book
            {
                Title = request.Title,
                Author = request.Author,
                Description = request.Description,
                CategoryId = request.CategoryId,
                ImageUrl = request.ImageUrl
            };

            var createdBook = await this.bookRepository.AddBookAsync(book);

            return new CreateBookDto
            {
                Id = createdBook.Id,
                Title = createdBook.Title,
                Author = createdBook.Author,
                Description = createdBook.Description,
                CategoryId = createdBook.CategoryId,
                ImageUrl = createdBook.ImageUrl,
            };
        }
    }
}
