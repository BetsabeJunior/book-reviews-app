// <copyright file="BookRepository.cs" company="Controlbox">
// Copyright (c) Controlbox. All rights reserved.
// </copyright>

namespace Controlbox.Infrastructure.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Controlbox.Application.Common.Interfaces;
    using Controlbox.Domain.Entities;
    using Controlbox.Infrastructure.Data;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Repository for book data actions.
    /// </summary>
    public class BookRepository : IBookRepository
    {
        /// <summary>
        /// The database context.
        /// </summary>
        private readonly ApplicationDbContext dbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The application database context.</param>
        public BookRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        /// <inheritdoc/>
        public async Task<List<Book>> GetAllBooksAsync()
        {
            return await this.dbContext.Books
                .Include(b => b.Category)
                .ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<Book?> GetBookWithReviewsAsync(int id)
        {
            return await this.dbContext.Books
                .Include(b => b.Category)
                .Include(b => b.Reviews)
                    .ThenInclude(r => r.User)
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        /// <inheritdoc/>
        public async Task<Book> AddBookAsync(Book book)
        {
            this.dbContext.Books.Add(book);
            await this.dbContext.SaveChangesAsync();
            return book;
        }

        /// <inheritdoc/>
        public async Task<bool> UpdateBookAsync(int id, string title, string author, int categoryId, string description)
        {
            var book = await this.dbContext.Books.FindAsync(id);

            if (book == null)
            {
                return false;
            }

            book.Title = title;
            book.Author = author;
            book.CategoryId = categoryId;
            book.Description = description;

            await this.dbContext.SaveChangesAsync();
            return true;
        }

        /// <inheritdoc/>
        public async Task<bool> DeleteBookAsync(int id)
        {
            var book = await this.dbContext.Books.FindAsync(id);

            if (book == null)
            {
                return false;
            }

            this.dbContext.Books.Remove(book);
            await this.dbContext.SaveChangesAsync();
            return true;
        }
    }
}
