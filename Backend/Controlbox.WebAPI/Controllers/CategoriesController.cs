// <copyright file="CategoriesController.cs" company="Controlbox">
// Copyright (c) Controlbox. All rights reserved.
// </copyright>

namespace Controlbox.API.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Controlbox.Application.Categories.Commands.CreateCategory;
    using Controlbox.Application.Categories.Commands.DeleteCategory;
    using Controlbox.Application.Categories.Commands.UpdateCategory;
    using Controlbox.Application.Categories.Dtos;
    using Controlbox.Application.Categories.Queries.GetAllCategories;
    using Controlbox.Application.Categories.Queries.GetCategoryById;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// This controller has actions for managing book categories.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="CategoriesController"/> class.
        /// </summary>
        /// <param name="mediator">The mediator service.</param>
        public CategoriesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Get all categories.
        /// </summary>
        /// <returns>List of category DTOs.</returns>
        /// <response code="200">Return all categories.</response>
        [HttpGet]
        [ProducesResponseType(typeof(List<CategoryDto>), 200)]
        public async Task<ActionResult<List<CategoryDto>>> GetAll()
        {
            var categories = await this.mediator.Send(new GetAllCategoriesQuery());
            return this.Ok(categories);
        }

        /// <summary>
        /// Get one category by ID.
        /// </summary>
        /// <param name="id">The category ID.</param>
        /// <returns>Category DTO if found.</returns>
        /// <response code="200">Return the category.</response>
        /// <response code="404">If the category is not found.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CategoryDto), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<CategoryDto>> GetById(int id)
        {
            var category = await this.mediator.Send(new GetCategoryByIdQuery { Id = id });

            if (category == null)
            {
                return this.NotFound();
            }

            return this.Ok(category);
        }

        /// <summary>
        /// Create a new category.
        /// </summary>
        /// <param name="command">The category data.</param>
        /// <returns>The new category ID.</returns>
        /// <response code="201">If the category was created.</response>
        /// <response code="401">If the user is not authorized.</response>
        [HttpPost]
        [Authorize]
        [ProducesResponseType(typeof(int), 201)]
        [ProducesResponseType(401)]
        public async Task<ActionResult<int>> Create([FromBody] CreateCategoryCommand command)
        {
            var result = await this.mediator.Send(command);
            return this.CreatedAtAction(nameof(this.GetById), new { id = result }, result);
        }

        /// <summary>
        /// Update one category.
        /// </summary>
        /// <param name="id">The category ID.</param>
        /// <param name="command">The new category data.</param>
        /// <returns>No content if success.</returns>
        /// <response code="204">If the category was updated.</response>
        /// <response code="400">If the ID in URL and body do not match.</response>
        /// <response code="401">If the user is not authorized.</response>
        /// <response code="404">If the category was not found.</response>
        [HttpPut("{id}")]
        [Authorize]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateCategoryCommand command)
        {
            if (id != command.Id)
            {
                return this.BadRequest("URL ID and command ID do not match.");
            }

            var updated = await this.mediator.Send(command);
            if (!updated)
            {
                return this.NotFound();
            }

            return this.NoContent();
        }

        /// <summary>
        /// Delete one category.
        /// </summary>
        /// <param name="id">The category ID.</param>
        /// <returns>No content if deleted.</returns>
        /// <response code="204">If the category was deleted.</response>
        /// <response code="401">If the user is not authorized.</response>
        /// <response code="404">If the category was not found.</response>
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(204)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await this.mediator.Send(new DeleteCategoryCommand { Id = id });

            if (!deleted)
            {
                return this.NotFound();
            }

            return this.NoContent();
        }
    }
}
