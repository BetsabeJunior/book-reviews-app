// <copyright file="IBookRepository.cs" company="Controlbox">
// Copyright (c) Controlbox. All rights reserved.
// </copyright>

namespace Controlbox.Application.Common.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Controlbox.Domain.Entities;

    /// <summary>
    /// Interface for book data actions.
    /// </summary>
    public interface IBookRepository
    {
        /// <summary>
        /// Gets all books.
        /// </summary>
        /// <returns>A list of books.</returns>
        Task<List<Book>> GetAllBooksAsync();

        /// <summary>
        /// Gets one book by id.
        /// </summary>
        /// <param name="id">The book id.</param>
        /// <returns>The book or null.</returns>
        Task<Book?> GetBookByIdAsync(int id);

        /// <summary>
        /// Adds a new book.
        /// </summary>
        /// <param name="book">The book to add.</param>
        /// <returns>The added book.</returns>
        Task<Book> AddBookAsync(Book book);

        /// <summary>
        /// Updates a book with new data.
        /// </summary>
        /// <param name="id">The book id.</param>
        /// <param name="title">The new title.</param>
        /// <param name="author">The new author.</param>
        /// <param name="categoryId">The new category id.</param>
        /// <param name="description">The new description.</param>
        /// <returns>True if book is updated; otherwise, false.</returns>
        Task<bool> UpdateBookAsync(int id, string title, string author, int categoryId, string description);

        /// <summary>
        /// Deletes a book by id.
        /// </summary>
        /// <param name="id">The book id.</param>
        /// <returns>True if deleted; otherwise, false.</returns>
        Task<bool> DeleteBookAsync(int id);
    }
}
