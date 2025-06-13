// <copyright file="JwtService.cs" company="Controlbox">
// Copyright (c) Controlbox. All rights reserved.
// </copyright>

namespace Controlbox.Infrastructure.Services
{
    using System;
    using System.Collections.Generic;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;
    using Controlbox.Application.Common.Interfaces;
    using Microsoft.Extensions.Configuration;
    using Microsoft.IdentityModel.Tokens;

    /// <summary>
    /// Provides JWT token generation.
    /// </summary>
    public class JwtService : IJwtService
    {
        private readonly IConfiguration configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="JwtService"/> class.
        /// </summary>
        /// <param name="configuration">The application configuration.</param>
        public JwtService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        /// <inheritdoc/>
        public string GenerateToken(int userId, string email, string name, string profilePicture)
        {
            profilePicture ??= string.Empty;

            var claims = new List<Claim>
               {
                   new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
                   new Claim(ClaimTypes.Email, email),
                   new Claim(ClaimTypes.Name, name),
                   new Claim("profile_picture", profilePicture),
               };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(this.configuration["Jwt:Key"]));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: this.configuration["Jwt:Issuer"],
                audience: this.configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
