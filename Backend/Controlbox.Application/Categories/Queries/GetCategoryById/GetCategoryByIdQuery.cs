// <copyright file="GetCategoryByIdQuery.cs" company="Controlbox">
// Copyright (c) Controlbox. All rights reserved.
// </copyright>

namespace Controlbox.Application.Categories.Queries.GetCategoryById
{
    using Controlbox.Application.Categories.Dtos;
    using MediatR;

    /// <summary>
    /// Query to get a category by ID.
    /// </summary>
    public class GetCategoryByIdQuery : IRequest<CategoryDto>
    {
        /// <summary>
        /// Gets or sets the category ID.
        /// </summary>
        public int Id { get; set; }
    }
}
