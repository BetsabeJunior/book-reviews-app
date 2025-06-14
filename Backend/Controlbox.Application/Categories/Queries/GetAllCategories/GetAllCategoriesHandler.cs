// <copyright file="GetAllCategoriesHandler.cs" company="Controlbox">
// Copyright (c) Controlbox. All rights reserved.
// </copyright>

namespace Controlbox.Application.Categories.Queries.GetAllCategories
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Controlbox.Application.Categories.Dtos;
    using Controlbox.Application.Common.Interfaces;
    using MediatR;

    /// <summary>
    /// Handles get all categories query.
    /// </summary>
    public class GetAllCategoriesHandler : IRequestHandler<GetAllCategoriesQuery, List<CategoryDto>>
    {
        private readonly ICategoryRepository categoryRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllCategoriesHandler"/> class.
        /// </summary>
        /// <param name="categoryRepository">The category repository.</param>
        public GetAllCategoriesHandler(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        /// <inheritdoc/>
        public async Task<List<CategoryDto>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = await this.categoryRepository.GetAllCategoriesAsync();

            return categories.Select(category => new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
            }).ToList();
        }
    }
}
