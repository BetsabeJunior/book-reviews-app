// <copyright file="BookController.cs" company="Controlbox">
// Copyright (c) Controlbox. All rights reserved.
// </copyright>

namespace Controlbox.Api.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Controlbox.Application.Books.Commands.CreateBook;
    using Controlbox.Application.Books.Commands.DeleteBook;
    using Controlbox.Application.Books.Commands.UpdateBook;
    using Controlbox.Application.Books.Dtos;
    using Controlbox.Application.Books.Queries.GetAllBooks;
    using Controlbox.Application.Books.Queries.GetBookById;
    using Controlbox.Application.Books.Queries.GetBooksByFilter;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Controller for book actions.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IMediator mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookController"/> class.
        /// </summary>
        /// <param name="mediator">The mediator service.</param>
        public BookController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Get all books.
        /// </summary>
        /// <returns>List of books.</returns>
        [HttpGet]
        public async Task<ActionResult<List<BookDto>>> GetAllBooks()
        {
            var books = await this.mediator.Send(new GetAllBooksQuery());
            return this.Ok(books);
        }

        /// <summary>
        /// Get books by filters.
        /// </summary>
        /// <param name="title">Book title (optional).</param>
        /// <param name="author">Book author (optional).</param>
        /// <param name="category">Book category (optional).</param>
        /// <returns>List of filtered books.</returns>
        [HttpGet("search")]
        public async Task<ActionResult<List<BookDto>>> GetBooksByFilter(
            [FromQuery] string? title,
            [FromQuery] string? author,
            [FromQuery] string? category)
        {
            var query = new GetBooksByFilterQuery
            {
                Title = title,
                Author = author,
                Category = category,
            };

            var books = await this.mediator.Send(query);
            return this.Ok(books);
        }

        /// <summary>
        /// Get one book by id.
        /// </summary>
        /// <param name="id">The book id.</param>
        /// <returns>The book or not found.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<BookDto>> GetBookById(int id)
        {
            var result = await this.mediator.Send(new GetBookByIdQuery { Id = id });

            if (result == null)
            {
                return this.NotFound();
            }

            return this.Ok(result);
        }

        /// <summary>
        /// Create one book.
        /// </summary>
        /// <param name="command">The book data.</param>
        /// <returns>The new book id.</returns>
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<int>> CreateBook([FromBody] CreateBookCommand command)
        {
            var id = await this.mediator.Send(command);
            return this.CreatedAtAction(nameof(this.GetBookById), new { id }, id);
        }

        /// <summary>
        /// Update one book.
        /// </summary>
        /// <param name="id">The book id.</param>
        /// <param name="command">The new data.</param>
        /// <returns>No content or not found.</returns>
        [HttpPut("{id}")]
        [Authorize]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] UpdateBookCommand command)
        {
            if (id != command.Id)
            {
                return this.BadRequest();
            }

            var result = await this.mediator.Send(command);

            if (!result.Success)
            {
                return this.NotFound();
            }

            return this.NoContent();
        }

        /// <summary>
        /// Delete one book.
        /// </summary>
        /// <param name="id">The book id.</param>
        /// <returns>No content or not found.</returns>
        [HttpDelete("{id}")]
        [Authorize]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var result = await this.mediator.Send(new DeleteBookCommand { Id = id });

            if (!result)
            {
                return this.NotFound();
            }

            return this.NoContent();
        }
    }
}
