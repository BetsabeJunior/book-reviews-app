// <copyright file="Category.cs" company="Controlbox">
// Copyright (c) Controlbox. All rights reserved.
// </copyright>

namespace Controlbox.Domain.Entities
{
    /// <summary>
    /// Represents a group of books with the same type.
    /// </summary>
    public class Category
    {
        /// <summary>
        /// Gets or sets the category ID.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the category name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the books in this category.
        /// </summary>
        public ICollection<Book>? Books { get; set; }
    }
}
