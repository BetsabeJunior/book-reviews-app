// <copyright file="GetCategoryByIdHandler.cs" company="Controlbox">
// Copyright (c) Controlbox. All rights reserved.
// </copyright>

namespace Controlbox.Application.Categories.Queries.GetCategoryById
{
    using System.Threading;
    using System.Threading.Tasks;
    using Controlbox.Application.Categories.Dtos;
    using Controlbox.Application.Common.Interfaces;
    using MediatR;

    /// <summary>
    /// Handles get category by ID query.
    /// </summary>
    public class GetCategoryByIdHandler : IRequestHandler<GetCategoryByIdQuery, CategoryDto>
    {
        private readonly ICategoryRepository categoryRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetCategoryByIdHandler"/> class.
        /// </summary>
        /// <param name="categoryRepository">The category repository.</param>
        public GetCategoryByIdHandler(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        /// <inheritdoc/>
        public async Task<CategoryDto> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var category = await this.categoryRepository.GetCategoryByIdAsync(request.Id);

            if (category == null)
            {
                return null;
            }

            return new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
            };
        }
    }
}
