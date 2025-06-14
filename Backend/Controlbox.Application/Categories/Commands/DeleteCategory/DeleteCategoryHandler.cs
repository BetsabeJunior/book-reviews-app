// <copyright file="DeleteCategoryHandler.cs" company="Controlbox">
// Copyright (c) Controlbox. All rights reserved.
// </copyright>

namespace Controlbox.Application.Categories.Commands.DeleteCategory
{
    using System.Threading;
    using System.Threading.Tasks;
    using Controlbox.Application.Common.Interfaces;
    using MediatR;

    /// <summary>
    /// Handles delete category command.
    /// </summary>
    public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryCommand, bool>
    {
        private readonly ICategoryRepository categoryRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteCategoryHandler"/> class.
        /// </summary>
        /// <param name="categoryRepository">The category repository.</param>
        public DeleteCategoryHandler(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        /// <inheritdoc/>
        public async Task<bool> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            return await this.categoryRepository.DeleteCategoryAsync(request.Id);
        }
    }
}
