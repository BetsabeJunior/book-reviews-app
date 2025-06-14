// <copyright file="CategoryDto.cs" company="Controlbox">
// Copyright (c) Controlbox. All rights reserved.
// </copyright>

namespace Controlbox.Application.Categories.Dtos
{
    /// <summary>
    /// Data transfer object for category.
    /// </summary>
    public class CategoryDto
    {
        /// <summary>
        /// Gets or sets category id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets category name.
        /// </summary>
        public string Name { get; set; }
    }
}
