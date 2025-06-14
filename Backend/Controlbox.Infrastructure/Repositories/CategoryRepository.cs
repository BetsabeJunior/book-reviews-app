// <copyright file="CategoryRepository.cs" company="Controlbox">
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
    /// Repository for category data actions.
    /// </summary>
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext dbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public CategoryRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        /// <inheritdoc/>
        public async Task<Category> AddCategoryAsync(Category category)
        {
            this.dbContext.Categories.Add(category);
            await this.dbContext.SaveChangesAsync();
            return category;
        }

        /// <inheritdoc/>
        public async Task<Category> UpdateCategoryAsync(Category category)
        {
            this.dbContext.Categories.Update(category);
            await this.dbContext.SaveChangesAsync();
            return category;
        }

        /// <inheritdoc/>
        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var category = await this.dbContext.Categories.FindAsync(id);
            if (category == null)
            {
                return false;
            }

            this.dbContext.Categories.Remove(category);
            await this.dbContext.SaveChangesAsync();
            return true;
        }

        /// <inheritdoc/>
        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            return await this.dbContext.Categories.ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await this.dbContext.Categories.FindAsync(id);
        }
    }
}
