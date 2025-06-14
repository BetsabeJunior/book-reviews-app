// <copyright file="ReviewDto.cs" company="Controlbox">
// Copyright (c) Controlbox. All rights reserved.
// </copyright>

namespace Controlbox.Application.Books.Dtos
{
    using System;

    /// <summary>
    /// Data transfer object for a review.
    /// </summary>
    public class ReviewDto
    {
        /// <summary>
        /// Gets or sets review id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets book id.
        /// </summary>
        public int BookId { get; set; }

        /// <summary>
        /// Gets or sets user id.
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Gets or sets username of the reviewer.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets user avatar URL.
        /// </summary>
        public string UserAvatar { get; set; }

        /// <summary>
        /// Gets or sets review rating (1 to 5).
        /// </summary>
        public int Rating { get; set; }

        /// <summary>
        /// Gets or sets review comment.
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// Gets or sets review creation date.
        /// </summary>
        public DateTime CreatedAt { get; set; }
    }
}
