// <copyright file="ReviewController.cs" company="Controlbox">
// Copyright (c) Controlbox. All rights reserved.
// </copyright>

namespace Controlbox.Api.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Controlbox.Application.Books.Dtos;
    using Controlbox.Application.Reviews.Commands.CreateReview;
    using Controlbox.Application.Reviews.Commands.DeleteReview;
    using Controlbox.Application.Reviews.Commands.UpdateReview;
    using Controlbox.Application.Reviews.Queries.GetAllReviews;
    using Controlbox.Application.Reviews.Queries.GetReviewById;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Controller for review actions.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewController : ControllerBase
    {
        private readonly IMediator mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReviewController"/> class.
        /// </summary>
        /// <param name="mediator">The mediator service.</param>
        public ReviewController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Gets all reviews.
        /// </summary>
        /// <returns>List of reviews.</returns>
        [HttpGet]
        public async Task<ActionResult<List<ReviewDto>>> GetAllReviews()
        {
            var result = await this.mediator.Send(new GetAllReviewsQuery());
            return this.Ok(result);
        }

        /// <summary>
        /// Gets one review by ID.
        /// </summary>
        /// <param name="id">The review ID.</param>
        /// <returns>The review or not found.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ReviewDto>> GetReviewById(int id)
        {
            var result = await this.mediator.Send(new GetReviewByIdQuery { Id = id });
            if (result == null)
            {
                return this.NotFound();
            }

            return this.Ok(result);
        }

        /// <summary>
        /// Creates a new review.
        /// </summary>
        /// <param name="command">The review data.</param>
        /// <returns>The created review.</returns>
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<ReviewDto>> CreateReview([FromBody] CreateReviewCommand command)
        {
            var review = await this.mediator.Send(command);
            return this.CreatedAtAction(nameof(this.GetReviewById), new { id = review.ToString() }, review);
        }

        /// <summary>
        /// Updates one review.
        /// </summary>
        /// <param name="id">The review ID.</param>
        /// <param name="command">The new data.</param>
        /// <returns>No content if ok.</returns>
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateReview(int id, [FromBody] UpdateReviewCommand command)
        {
            if (id != command.Id)
            {
                return this.BadRequest();
            }

            var result = await this.mediator.Send(command);
            if (!result)
            {
                return this.NotFound();
            }

            return this.NoContent();
        }

        /// <summary>
        /// Deletes one review.
        /// </summary>
        /// <param name="id">The review ID.</param>
        /// <returns>No content if deleted.</returns>
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteReview(int id)
        {
            var result = await this.mediator.Send(new DeleteReviewCommand { Id = id });
            if (!result)
            {
                return this.NotFound();
            }

            return this.NoContent();
        }
    }
}
