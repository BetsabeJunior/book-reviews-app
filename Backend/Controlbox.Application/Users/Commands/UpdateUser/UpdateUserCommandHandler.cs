// UpdateUserCommandHandler.cs
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Controlbox.Application.Common.DTOs;
using Controlbox.Application.Common.Interfaces;
using Controlbox.Application.Users.Dtos;
using Controlbox.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Controlbox.Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, AuthResponseDto?>
    {
        private readonly IUserRepository userRepository;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IJwtService jwtService;

        public UpdateUserCommandHandler(
            IUserRepository userRepository,
            IHttpContextAccessor httpContextAccessor,
            IJwtService jwtService)
        {
            this.userRepository = userRepository;
            this.httpContextAccessor = httpContextAccessor;
            this.jwtService = jwtService;
        }

        public async Task<AuthResponseDto?> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var userIdClaim = this.httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier);

            if (userIdClaim == null
                || string.IsNullOrEmpty(userIdClaim.Value)
                || !int.TryParse(userIdClaim.Value, out int loggedUserId)
                || loggedUserId != request.UserId)
            {
                return null;
            }

            var user = await this.userRepository.GetUserByIdAsync(request.UserId);

            if (user == null)
            {
                return null;
            }

            user.Name = request.Name;
            user.Email = request.Email;
            user.ProfilePicture = request.ProfilePicture;

            var updated = await this.userRepository.UpdateUserAsync(user);

            if (!updated)
            {
                return null;
            }

            var token = this.jwtService.GenerateToken(user.Id, user.Email, user.Name, user.ProfilePicture);

            return new AuthResponseDto
            {
                Token = token,
                User = new UserDto
                {
                    Id = user.Id,
                    Name = user.Name,
                    Email = user.Email,
                    ProfilePicture = user.ProfilePicture,
                }
            };
        }
    }
}
