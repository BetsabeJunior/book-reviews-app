// <copyright file="CreateCategoryCommand.cs" company="Controlbox">
// Copyright (c) Controlbox. All rights reserved.
// </copyright>

namespace Controlbox.Application.Categories.Commands.CreateCategory
{
    using MediatR;

    /// <summary>
    /// This command creates a new category.
    /// </summary>
    public class CreateCategoryCommand : IRequest<int>
    {
        /// <summary>
        /// Gets or sets the name of the category.
        /// </summary>
        public string Name { get; set; } = string.Empty;
    }
}
