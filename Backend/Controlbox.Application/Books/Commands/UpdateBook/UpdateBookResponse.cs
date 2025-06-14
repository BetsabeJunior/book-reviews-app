// <copyright file="UpdateBookResponse.cs" company="Controlbox">
// Copyright (c) Controlbox. All rights reserved.
// </copyright>

namespace Controlbox.Application.Books.Commands.UpdateBook
{
    /// <summary>
    /// Response returned after updating a book.
    /// </summary>
    public class UpdateBookResponse
    {
        /// <summary>
        /// Gets or sets a value indicating whether the update was successful.
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Gets or sets the response message.
        /// </summary>
        public string Message { get; set; } = string.Empty;
    }
}
