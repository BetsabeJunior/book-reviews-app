// <copyright file="DeleteCategoryCommand.cs" company="Controlbox">
// Copyright (c) Controlbox. All rights reserved.
// </copyright>

namespace Controlbox.Application.Categories.Commands.DeleteCategory
{
    using MediatR;

    /// <summary>
    /// This command deletes a category.
    /// </summary>
    public class DeleteCategoryCommand : IRequest<bool>
    {
        /// <summary>
        /// Gets or sets the category id.
        /// </summary>
        public int Id { get; set; }
    }
}
