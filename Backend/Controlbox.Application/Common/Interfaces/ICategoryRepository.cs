// <copyright file="ICategoryRepository.cs" company="Controlbox">
// Copyright (c) Controlbox. All rights reserved.
// </copyright>

namespace Controlbox.Application.Common.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Controlbox.Domain.Entities;

    /// <summary>
    /// Interface for category data actions.
    /// </summary>
    public interface ICategoryRepository
    {
        /// <summary>
        /// Adds a new category.
        /// </summary>
        /// <param name="category">The category to add.</param>
        /// <returns>The added category.</returns>
        Task<Category> AddCategoryAsync(Category category);

        /// <summary>
        /// Updates a category.
        /// </summary>
        /// <param name="category">The category to update.</param>
        /// <returns>The updated category.</returns>
        Task<Category> UpdateCategoryAsync(Category category);

        /// <summary>
        /// Deletes a category by ID.
        /// </summary>
        /// <param name="id">The ID of the category to delete.</param>
        /// <returns>True if deleted, false otherwise.</returns>
        Task<bool> DeleteCategoryAsync(int id);

        /// <summary>
        /// Gets all categories.
        /// </summary>
        /// <returns>List of categories.</returns>
        Task<List<Category>> GetAllCategoriesAsync();

        /// <summary>
        /// Gets one category by ID.
        /// </summary>
        /// <param name="id">The category ID.</param>
        /// <returns>The category or null.</returns>
        Task<Category> GetCategoryByIdAsync(int id);
    }
}
