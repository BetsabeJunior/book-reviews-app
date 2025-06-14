// <copyright file="ReviewRepository.cs" company="Controlbox">
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
    /// Implements review data actions.
    /// </summary>
    public class ReviewRepository : IReviewRepository
    {
        private readonly ApplicationDbContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReviewRepository"/> class.
        /// </summary>
        /// <param name="context">The database context.</param>
        public ReviewRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        /// <inheritdoc/>
        public async Task<List<Review>> GetAllReviewsAsync()
        {
            return await this.context.Reviews
                .Include(r => r.User)
                .Include(r => r.Book)
                .OrderByDescending(r => r.Id)
                .ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<Review> AddReviewAsync(Review review)
        {
            this.context.Reviews.Add(review);
            await this.context.SaveChangesAsync();
            return review;
        }

        /// <inheritdoc/>
        public async Task<List<Review>> GetReviewsByBookIdAsync(int bookId)
        {
            return await this.context.Reviews
                .Where(r => r.BookId == bookId)
                .Include(r => r.User)
                .OrderByDescending(r => r.Id)
                .ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<Review> GetReviewByIdAsync(int id)
        {
            return await this.context.Reviews
                .Include(r => r.User)
                .Include(r => r.Book)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        /// <inheritdoc/>
        public async Task<bool> UpdateReviewAsync(int id, string comment, int rating)
        {
            var review = await this.context.Reviews.FindAsync(id);

            if (review == null)
            {
                return false;
            }

            review.Comment = comment;
            review.Rating = rating;

            await this.context.SaveChangesAsync();
            return true;
        }

        /// <inheritdoc/>
        public async Task<bool> DeleteReviewAsync(int id)
        {
            var review = await this.context.Reviews.FindAsync(id);

            if (review == null)
            {
                return false;
            }

            this.context.Reviews.Remove(review);
            await this.context.SaveChangesAsync();
            return true;
        }
    }
}
