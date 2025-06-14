// <copyright file="UpdateCategoryCommand.cs" company="Controlbox">
// Copyright (c) Controlbox. All rights reserved.
// </copyright>

namespace Controlbox.Application.Categories.Commands.UpdateCategory
{
    using MediatR;

    /// <summary>
    /// Command to update a category.
    /// </summary>
    public class UpdateCategoryCommand : IRequest<bool>
    {
        /// <summary>
        /// Gets or sets the category ID.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the category name.
        /// </summary>
        public string Name { get; set; } = string.Empty;
    }
}
