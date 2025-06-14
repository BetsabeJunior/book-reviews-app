// <copyright file="DeleteBookHandler.cs" company="Controlbox">
// Copyright (c) Controlbox. All rights reserved.
// </copyright>

namespace Controlbox.Application.Books.Commands.DeleteBook
{
    using System.Threading;
    using System.Threading.Tasks;
    using Controlbox.Application.Common.Interfaces;
    using MediatR;

    /// <summary>
    /// Handler to delete a book.
    /// </summary>
    public class DeleteBookHandler : IRequestHandler<DeleteBookCommand, bool>
    {
        private readonly IBookRepository bookRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteBookHandler"/> class.
        /// </summary>
        /// <param name="bookRepository">The book repository.</param>
        public DeleteBookHandler(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        /// <inheritdoc/>
        public async Task<bool> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            return await this.bookRepository.DeleteBookAsync(request.Id);
        }
    }
}
