// <copyright file="UpdateCategoryHandler.cs" company="Controlbox">
// Copyright (c) Controlbox. All rights reserved.
// </copyright>

namespace Controlbox.Application.Categories.Commands.UpdateCategory
{
    using System.Threading;
    using System.Threading.Tasks;
    using Controlbox.Application.Common.Interfaces;
    using Controlbox.Domain.Entities;
    using MediatR;

    /// <summary>
    /// Handles the update category command.
    /// </summary>
    public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryCommand, bool>
    {
        private readonly ICategoryRepository categoryRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateCategoryHandler"/> class.
        /// </summary>
        /// <param name="categoryRepository">The category repository.</param>
        public UpdateCategoryHandler(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        /// <summary>
        /// Handles the update category logic.
        /// </summary>
        /// <param name="request">The update command.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>True if updated; false otherwise.</returns>
        public async Task<bool> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new Category
            {
                Id = request.Id,
                Name = request.Name,
            };

            var result = await this.categoryRepository.UpdateCategoryAsync(category);

            return result != null;
        }
    }
}
