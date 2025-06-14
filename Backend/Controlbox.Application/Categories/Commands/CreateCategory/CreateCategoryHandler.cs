// <copyright file="CreateCategoryHandler.cs" company="Controlbox">
// Copyright (c) Controlbox. All rights reserved.
// </copyright>

namespace Controlbox.Application.Categories.Commands.CreateCategory
{
    using System.Threading;
    using System.Threading.Tasks;
    using Controlbox.Application.Common.Interfaces;
    using Controlbox.Domain.Entities;
    using MediatR;

    /// <summary>
    /// Handles create category command.
    /// </summary>
    public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand, int>
    {
        private readonly ICategoryRepository categoryRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateCategoryHandler"/> class.
        /// </summary>
        /// <param name="categoryRepository">The category repository.</param>
        public CreateCategoryHandler(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        /// <summary>
        /// Handles the create category command.
        /// </summary>
        /// <param name="request">The create category command.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The ID of the created category.</returns>
        public async Task<int> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new Category
            {
                Name = request.Name,
            };

            var created = await this.categoryRepository.AddCategoryAsync(category);

            return created.Id;
        }
    }
}
