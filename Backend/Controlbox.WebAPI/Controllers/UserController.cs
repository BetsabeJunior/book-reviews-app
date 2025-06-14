// <copyright file="UserController.cs" company="Controlbox">
// Copyright (c) Controlbox. All rights reserved.
// </copyright>

namespace Controlbox.Api.Controllers
{
    using System.Threading.Tasks;
    using Controlbox.Application.Users.Commands.LoginUser;
    using Controlbox.Application.Users.Commands.RegisterUser;
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
        /// Register a new user and return a JWT token.
        /// </summary>
        /// <param name="command">The user registration data.</param>
        /// <returns>The JWT token if successful.</returns>
        [HttpPost("register")]
        public async Task<ActionResult<string>> Register([FromBody] RegisterUserCommand command)
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

            string? token = await this.mediator.Send(loginCommand);

            if (string.IsNullOrWhiteSpace(token))
            {
                return this.Unauthorized("User registered but login failed.");
            }

            return this.Ok(token);
        }

        /// <summary>
        /// Login with email and password.
        /// </summary>
        /// <param name="command">The login data.</param>
        /// <returns>The JWT token.</returns>
        [HttpPost("login")]
        public async Task<ActionResult<string>> Login([FromBody] LoginUserCommand command)
        {
            string? token = await this.mediator.Send(command);

            if (string.IsNullOrWhiteSpace(token))
            {
                return this.Unauthorized("Invalid email or password.");
            }

            return this.Ok(token);
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

    }
}
