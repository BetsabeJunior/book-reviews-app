// <copyright file="MappingProfile.cs" company="Controlbox">
// Copyright (c) Controlbox. All rights reserved.
// </copyright>

namespace Controlbox.Application.Common.Mappings
{
    using AutoMapper;
    using Controlbox.Application.Books.Dtos;
    using Controlbox.Application.Categories.Dtos;
    using Controlbox.Application.Users.Dtos;
    using Controlbox.Application.Users.Queries.GetUserProfile;
    using Controlbox.Domain.Entities;
    using static System.Runtime.InteropServices.JavaScript.JSType;

    /// <summary>
    /// Mapping profile for AutoMapper.
    /// </summary>
    public class MappingProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MappingProfile"/> class.
        /// </summary>
        public MappingProfile()
        {
            // Book mappings
            this.CreateMap<Book, BookDto>()
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.Name))
                .ReverseMap();


            // Category mappings
            this.CreateMap<Category, CategoryDto>().ReverseMap();

            // Review mappings
            this.CreateMap<Review, ReviewDto>()
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.User.Name))
                .ReverseMap();

            // User mappings
            this.CreateMap<User, UserProfileDto>().ReverseMap();
        }
    }
}
