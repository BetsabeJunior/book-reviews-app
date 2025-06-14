// <copyright file="GetAllCategoriesQuery.cs" company="Controlbox">
// Copyright (c) Controlbox. All rights reserved.
// </copyright>

namespace Controlbox.Application.Categories.Queries.GetAllCategories
{
    using System.Collections.Generic;
    using Controlbox.Application.Categories.Dtos;
    using MediatR;

    /// <summary>
    /// Query to get all categories.
    /// </summary>
    public class GetAllCategoriesQuery : IRequest<List<CategoryDto>>
    {
    }
}
