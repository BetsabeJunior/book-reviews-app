// <copyright file="ReviewDto.cs" company="Controlbox">
// Copyright (c) Controlbox. All rights reserved.
// </copyright>

namespace Controlbox.Application.Reviews.Dtos
{
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
        /// Gets or sets user name.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets rating from 1 to 5.
        /// </summary>
        public int Rating { get; set; }

        /// <summary>
        /// Gets or sets review comment.
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// Gets or sets review date.
        /// </summary>
        public DateTime Date { get; set; }
    }
}
