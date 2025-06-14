// <copyright file="UserController.cs" company="Controlbox">
// Copyright (c) Controlbox. All rights reserved.
// </copyright>

namespace Controlbox.Api.Controllers
{
    using System.Threading.Tasks;
    using Controlbox.Application.Common.DTOs;
    using Controlbox.Application.Users.Commands.LoginUser;
    using Controlbox.Application.Users.Commands.RegisterUser;
    using Controlbox.Application.Users.Commands.UpdateUser;
    using Controlbox.Application.Users.Dtos;
    using Controlbox.Application.Users.Queries.GetUserProfile;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Controller for user actions.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        /// <param name="mediator">The mediator service.</param>
        public UserController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Register a new user and return token and user data.
        /// </summary>
        /// <param name="command">The user registration data.</param>
        /// <returns>The JWT token and user information if successful.</returns>
        [HttpPost("register")]
        public async Task<ActionResult<AuthResponseDto>> Register([FromBody] RegisterUserCommand command)
        {
            int userId = await this.mediator.Send(command);

            if (userId <= 0)
            {
                return this.BadRequest("User registration failed.");
            }

            var loginCommand = new LoginUserCommand
            {
                Email = command.Email,
                Password = command.Password,
            };

            AuthResponseDto? result = await this.mediator.Send(loginCommand);

            if (result == null)
            {
                return this.Unauthorized("User registered but login failed.");
            }

            return this.Ok(result);
        }

        /// <summary>
        /// Login with email and password.
        /// </summary>
        /// <param name="command">The login data.</param>
        /// <returns>The JWT token and user information.</returns>
        [HttpPost("login")]
        public async Task<ActionResult<AuthResponseDto>> Login([FromBody] LoginUserCommand command)
        {
            AuthResponseDto? result = await this.mediator.Send(command);

            if (result == null)
            {
                return this.Unauthorized("Invalid email or password.");
            }

            return this.Ok(result);
        }

        /// <summary>
        /// Get user profile.
        /// </summary>
        /// <returns>User profile data.</returns>
        [HttpGet("profile")]
        [Authorize]
        public async Task<ActionResult<UserProfileDto>> GetProfile()
        {
            var result = await this.mediator.Send(new GetUserProfileQuery());
            return this.Ok(result);
        }

        /// <summary>
        /// Update one user.
        /// </summary>
        /// <param name="id">The user ID.</param>
        /// <param name="command">The new user data (without ID).</param>
        /// <returns>No content if successful.</returns>
        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<AuthResponseDto>> UpdateUser(int id, [FromBody] UpdateUserDto command)
        {
            var updateCommand = new UpdateUserCommand
            {
                UserId = id,
                Name = command.Name,
                Email = command.Email,
                ProfilePicture = command.ProfilePicture,
            };

            var result = await this.mediator.Send(updateCommand);

            if (result == null)
            {
                return this.NotFound("User not found or update failed.");
            }

            return this.Ok(result);
        }
    }
}
