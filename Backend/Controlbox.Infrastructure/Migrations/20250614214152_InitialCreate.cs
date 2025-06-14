using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Controlbox.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    profile_picture = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "books",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: false),
                    author = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    image_url = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    category_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_books", x => x.id);
                    table.ForeignKey(
                        name: "FK_books_categories_category_id",
                        column: x => x.category_id,
                        principalTable: "categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "reviews",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    comment = table.Column<string>(type: "text", nullable: false),
                    rating = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    book_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reviews", x => x.id);
                    table.ForeignKey(
                        name: "FK_reviews_books_book_id",
                        column: x => x.book_id,
                        principalTable: "books",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_reviews_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "Fantasía" },
                    { 2, "Ciencia Ficción" },
                    { 3, "Romance" },
                    { 4, "Historia" },
                    { 5, "Aventura" }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "created_at", "email", "name", "password", "profile_picture" },
                values: new object[] { 1, new DateTime(2025, 6, 13, 0, 0, 0, 0, DateTimeKind.Utc), "admin@gmail.com", "Admin", "$2a$11$C.XVRF2r7PZ7sLOLRtTsN.KYTs33mfHxNDsYwy6gycczIfNn.eZza", "" });

            migrationBuilder.InsertData(
                table: "books",
                columns: new[] { "id", "author", "category_id", "created_at", "description", "image_url", "title" },
                values: new object[,]
                {
                    { 1, "J.R.R. Tolkien", 1, new DateTime(2025, 6, 13, 0, 0, 0, 0, DateTimeKind.Utc), "Una aventura épica en la Tierra Media.", "", "El Señor de los Anillos" },
                    { 2, "Frank Herbert", 2, new DateTime(2025, 6, 13, 0, 0, 0, 0, DateTimeKind.Utc), "Una historia de poder y desierto.", "", "Dune" },
                    { 3, "Jane Austen", 3, new DateTime(2025, 6, 13, 0, 0, 0, 0, DateTimeKind.Utc), "Romance clásico del siglo XIX.", "", "Orgullo y Prejuicio" },
                    { 4, "Yuval Noah Harari", 4, new DateTime(2025, 6, 13, 0, 0, 0, 0, DateTimeKind.Utc), "Historia de la humanidad.", "", "Sapiens" },
                    { 5, "R.L. Stevenson", 5, new DateTime(2025, 6, 13, 0, 0, 0, 0, DateTimeKind.Utc), "Búsqueda de un tesoro escondido.", "", "La Isla del Tesoro" },
                    { 6, "J.K. Rowling", 1, new DateTime(2025, 6, 13, 0, 0, 0, 0, DateTimeKind.Utc), "El inicio de una saga mágica.", "", "Harry Potter y la Piedra Filosofal" },
                    { 7, "William Gibson", 2, new DateTime(2025, 6, 13, 0, 0, 0, 0, DateTimeKind.Utc), "Ciberpunk y hackers del futuro.", "", "Neuromante" },
                    { 8, "Emily Brontë", 3, new DateTime(2025, 6, 13, 0, 0, 0, 0, DateTimeKind.Utc), "Romance oscuro en los páramos.", "", "Cumbres Borrascosas" },
                    { 9, "Ken Follett", 4, new DateTime(2025, 6, 13, 0, 0, 0, 0, DateTimeKind.Utc), "Construcción de una catedral en la Edad Media.", "", "Los Pilares de la Tierra" },
                    { 10, "Jules Verne", 5, new DateTime(2025, 6, 13, 0, 0, 0, 0, DateTimeKind.Utc), "Exploración subterránea asombrosa.", "", "Viaje al Centro de la Tierra" },
                    { 11, "J.R.R. Tolkien", 1, new DateTime(2025, 6, 13, 0, 0, 0, 0, DateTimeKind.Utc), "La primera aventura de Bilbo Bolsón.", "", "El Hobbit" },
                    { 12, "Ray Bradbury", 2, new DateTime(2025, 6, 13, 0, 0, 0, 0, DateTimeKind.Utc), "Relatos sobre la colonización de Marte.", "", "Crónicas Marcianas" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_books_category_id",
                table: "books",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_reviews_book_id",
                table: "reviews",
                column: "book_id");

            migrationBuilder.CreateIndex(
                name: "IX_reviews_user_id",
                table: "reviews",
                column: "user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "reviews");

            migrationBuilder.DropTable(
                name: "books");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "categories");
        }
    }
}
