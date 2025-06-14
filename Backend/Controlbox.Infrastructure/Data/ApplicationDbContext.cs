// <copyright file="ApplicationDbContext.cs" company="Controlbox">
// Copyright (c) Controlbox. All rights reserved.
// </copyright>

namespace Controlbox.Infrastructure.Data
{
    using System;
    using BCrypt.Net;
    using Controlbox.Domain.Entities;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// The main database context for the application.
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationDbContext"/> class.
        /// </summary>
        /// <param name="options">The options to configure the context.</param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the books.
        /// </summary>
        public DbSet<Book> Books { get; set; }

        /// <summary>
        /// Gets or sets the categories.
        /// </summary>
        public DbSet<Category> Categories { get; set; }

        /// <summary>
        /// Gets or sets the users.
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Gets or sets the reviews.
        /// </summary>
        public DbSet<Review> Reviews { get; set; }

        /// <inheritdoc/>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Book
            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("books");

                entity.HasKey(b => b.Id);
                entity.Property(b => b.Id).HasColumnName("id");
                entity.Property(b => b.Title).HasColumnName("title");
                entity.Property(b => b.Author).HasColumnName("author");
                entity.Property(b => b.Description).HasColumnName("description");
                entity.Property(b => b.ImageUrl).HasColumnName("image_url");
                entity.Property(b => b.CreatedAt).HasColumnName("created_at");
                entity.Property(b => b.CategoryId).HasColumnName("category_id");

                entity.HasOne(b => b.Category)
                      .WithMany(c => c.Books)
                      .HasForeignKey(b => b.CategoryId)
                      .OnDelete(DeleteBehavior.SetNull);
            });

            // Category
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("categories");

                entity.HasKey(c => c.Id);
                entity.Property(c => c.Id).HasColumnName("id");
                entity.Property(c => c.Name).HasColumnName("name");

                entity.HasMany(c => c.Books)
                      .WithOne(b => b.Category)
                      .HasForeignKey(b => b.CategoryId)
                      .OnDelete(DeleteBehavior.SetNull);
            });

            // User
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.HasKey(u => u.Id);
                entity.Property(u => u.Id).HasColumnName("id");
                entity.Property(u => u.Name).HasColumnName("name");
                entity.Property(u => u.Email).HasColumnName("email");
                entity.Property(u => u.Password).HasColumnName("password");
                entity.Property(u => u.ProfilePicture).HasColumnName("profile_picture");
                entity.Property(u => u.CreatedAt).HasColumnName("created_at");

                entity.HasMany(u => u.Reviews)
                      .WithOne(r => r.User)
                      .HasForeignKey(r => r.UserId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Review
            modelBuilder.Entity<Review>(entity =>
            {
                entity.ToTable("reviews");

                entity.HasKey(r => r.Id);
                entity.Property(r => r.Id).HasColumnName("id");
                entity.Property(r => r.UserId).HasColumnName("user_id");
                entity.Property(r => r.BookId).HasColumnName("book_id");
                entity.Property(r => r.Comment).HasColumnName("comment");
                entity.Property(r => r.Rating).HasColumnName("rating");
                entity.Property(r => r.CreatedAt).HasColumnName("created_at");

                entity.HasOne(r => r.User)
                      .WithMany(u => u.Reviews)
                      .HasForeignKey(r => r.UserId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(r => r.Book)
                      .WithMany(b => b.Reviews)
                      .HasForeignKey(r => r.BookId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Seed categories
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Fantasía" },
                new Category { Id = 2, Name = "Ciencia Ficción" },
                new Category { Id = 3, Name = "Romance" },
                new Category { Id = 4, Name = "Historia" },
                new Category { Id = 5, Name = "Aventura" });

            // Seed admin user
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Name = "Admin",
                    Email = "admin@gmail.com",
                    Password = "$2a$11$C.XVRF2r7PZ7sLOLRtTsN.KYTs33mfHxNDsYwy6gycczIfNn.eZza",
                    ProfilePicture = string.Empty,
                    CreatedAt = new DateTime(2025, 6, 13, 0, 0, 0, DateTimeKind.Utc),
                });

            DateTime seedDate = new DateTime(2025, 6, 13, 0, 0, 0, DateTimeKind.Utc);

            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "El Señor de los Anillos", Author = "J.R.R. Tolkien", Description = "Una aventura épica en la Tierra Media.", ImageUrl = "", CreatedAt = seedDate, CategoryId = 1 },
                new Book { Id = 2, Title = "Dune", Author = "Frank Herbert", Description = "Una historia de poder y desierto.", ImageUrl = "", CreatedAt = seedDate, CategoryId = 2 },
                new Book { Id = 3, Title = "Orgullo y Prejuicio", Author = "Jane Austen", Description = "Romance clásico del siglo XIX.", ImageUrl = "", CreatedAt = seedDate, CategoryId = 3 },
                new Book { Id = 4, Title = "Sapiens", Author = "Yuval Noah Harari", Description = "Historia de la humanidad.", ImageUrl = "", CreatedAt = seedDate, CategoryId = 4 },
                new Book { Id = 5, Title = "La Isla del Tesoro", Author = "R.L. Stevenson", Description = "Búsqueda de un tesoro escondido.", ImageUrl = "", CreatedAt = seedDate, CategoryId = 5 },
                new Book { Id = 6, Title = "Harry Potter y la Piedra Filosofal", Author = "J.K. Rowling", Description = "El inicio de una saga mágica.", ImageUrl = "", CreatedAt = seedDate, CategoryId = 1 },
                new Book { Id = 7, Title = "Neuromante", Author = "William Gibson", Description = "Ciberpunk y hackers del futuro.", ImageUrl = "", CreatedAt = seedDate, CategoryId = 2 },
                new Book { Id = 8, Title = "Cumbres Borrascosas", Author = "Emily Brontë", Description = "Romance oscuro en los páramos.", ImageUrl = "", CreatedAt = seedDate, CategoryId = 3 },
                new Book { Id = 9, Title = "Los Pilares de la Tierra", Author = "Ken Follett", Description = "Construcción de una catedral en la Edad Media.", ImageUrl = "", CreatedAt = seedDate, CategoryId = 4 },
                new Book { Id = 10, Title = "Viaje al Centro de la Tierra", Author = "Jules Verne", Description = "Exploración subterránea asombrosa.", ImageUrl = "", CreatedAt = seedDate, CategoryId = 5 },
                new Book { Id = 11, Title = "El Hobbit", Author = "J.R.R. Tolkien", Description = "La primera aventura de Bilbo Bolsón.", ImageUrl = "", CreatedAt = seedDate, CategoryId = 1 },
                new Book { Id = 12, Title = "Crónicas Marcianas", Author = "Ray Bradbury", Description = "Relatos sobre la colonización de Marte.", ImageUrl = "", CreatedAt = seedDate, CategoryId = 2 }
            );
        }
    }
}
