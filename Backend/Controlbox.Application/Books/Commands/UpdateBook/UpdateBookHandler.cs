// <copyright file="UpdateBookHandler.cs" company="Controlbox">
// Copyright (c) Controlbox. All rights reserved.
// </copyright>

namespace Controlbox.Application.Books.Commands.UpdateBook
{
    using System.Threading;
    using System.Threading.Tasks;
    using Controlbox.Application.Common.Interfaces;
    using MediatR;

    /// <summary>
    /// Handles the update book command.
    /// </summary>
    public class UpdateBookHandler : IRequestHandler<UpdateBookCommand, UpdateBookResponse>
    {
        private readonly IBookRepository bookRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateBookHandler"/> class.
        /// </summary>
        /// <param name="bookRepository">The book repository.</param>
        public UpdateBookHandler(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        /// <inheritdoc/>
        public async Task<UpdateBookResponse> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            if (!request.CategoryId.HasValue)
            {
                return new UpdateBookResponse
                {
                    Success = false,
                    Message = "Category ID is required.",
                };
            }

            var result = await this.bookRepository.UpdateBookAsync(
                request.Id,
                request.Title,
                request.Author,
                request.CategoryId.Value,
                request.Description);

            return new UpdateBookResponse
            {
                Success = result,
                Message = result ? "Book updated successfully." : "Book not found or not updated.",
            };
        }
    }
}
