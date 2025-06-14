// <copyright file="InfrastructureServiceRegistration.cs" company="Controlbox">
// Copyright (c) Controlbox. All rights reserved.
// </copyright>

namespace Controlbox.Infrastructure.DependencyInjection
{
    using Controlbox.Application.Common.Interfaces;
    using Controlbox.Infrastructure.Data;
    using Controlbox.Infrastructure.Repositories;
    using Controlbox.Infrastructure.Services;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// Provides services registration for the infrastructure layer.
    /// </summary>
    public static class InfrastructureServiceRegistration
    {
        /// <summary>
        /// Adds infrastructure services to the application.
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <param name="configuration">The configuration data.</param>
        /// <returns>The updated service collection.</returns>
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("SQLConnection")));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IReviewRepository, ReviewRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddScoped<ICurrentUserService, CurrentUserService>();

            return services;
        }
    }
}
