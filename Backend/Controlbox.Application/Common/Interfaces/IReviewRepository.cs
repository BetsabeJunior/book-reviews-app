// <copyright file="IReviewRepository.cs" company="Controlbox">
// Copyright (c) Controlbox. All rights reserved.
// </copyright>

namespace Controlbox.Application.Common.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Controlbox.Domain.Entities;

    /// <summary>
    /// Interface for review data actions.
    /// </summary>
    public interface IReviewRepository
    {
        /// <summary>
        /// Adds a review for a book.
        /// </summary>
        /// <param name="review">The review to add.</param>
        /// <returns>The added review.</returns>
        Task<Review> AddReviewAsync(Review review);

        /// <summary>
        /// Gets all reviews for one book.
        /// </summary>
        /// <param name="bookId">The book id.</param>
        /// <returns>List of reviews.</returns>
        Task<List<Review>> GetReviewsByBookIdAsync(int bookId);

        /// <summary>
        /// Gets one review by id.
        /// </summary>
        /// <param name="id">The review id.</param>
        /// <returns>The review or null.</returns>
        Task<Review> GetReviewByIdAsync(int id);

        /// <summary>
        /// Gets all reviews.
        /// </summary>
        /// <returns>List of all reviews.</returns>
        Task<List<Review>> GetAllReviewsAsync();

        /// <summary>
        /// Updates a review by id.
        /// </summary>
        /// <param name="id">The review id.</param>
        /// <param name="text">The new review text.</param>
        /// <param name="rating">The new rating.</param>
        /// <returns>True if updated, false if not found.</returns>
        Task<bool> UpdateReviewAsync(int id, string text, int rating);

        /// <summary>
        /// Deletes a review by id.
        /// </summary>
        /// <param name="id">The review id.</param>
        /// <returns>True if deleted, false if not found.</returns>
        Task<bool> DeleteReviewAsync(int id);
    }
}
