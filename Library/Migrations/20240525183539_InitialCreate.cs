using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Library.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "author",
                columns: table => new
                {
                    author_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    first_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    last_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    birth_date = table.Column<DateOnly>(type: "date", nullable: true),
                    death_date = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("author_pkey", x => x.author_id);
                });

            migrationBuilder.CreateTable(
                name: "member",
                columns: table => new
                {
                    member_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    first_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    last_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    phone = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    membership_start_date = table.Column<DateOnly>(type: "date", nullable: false),
                    membership_end_date = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("member_pkey", x => x.member_id);
                });

            migrationBuilder.CreateTable(
                name: "publisher",
                columns: table => new
                {
                    publisher_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    address = table.Column<string>(type: "text", nullable: true),
                    phone = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("publisher_pkey", x => x.publisher_id);
                });

            migrationBuilder.CreateTable(
                name: "book",
                columns: table => new
                {
                    book_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    isbn = table.Column<string>(type: "character varying(13)", maxLength: 13, nullable: false),
                    publish_date = table.Column<DateOnly>(type: "date", nullable: true),
                    number_of_copies = table.Column<int>(type: "integer", nullable: false),
                    genre = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    publisher_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("book_pkey", x => x.book_id);
                    table.ForeignKey(
                        name: "book_publisher_id_fkey",
                        column: x => x.publisher_id,
                        principalTable: "publisher",
                        principalColumn: "publisher_id");
                });

            migrationBuilder.CreateTable(
                name: "bookauthor",
                columns: table => new
                {
                    book_author_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    book_id = table.Column<int>(type: "integer", nullable: true),
                    author_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("bookauthor_pkey", x => x.book_author_id);
                    table.ForeignKey(
                        name: "bookauthor_author_id_fkey",
                        column: x => x.author_id,
                        principalTable: "author",
                        principalColumn: "author_id");
                    table.ForeignKey(
                        name: "bookauthor_book_id_fkey",
                        column: x => x.book_id,
                        principalTable: "book",
                        principalColumn: "book_id");
                });

            migrationBuilder.CreateTable(
                name: "loan",
                columns: table => new
                {
                    loan_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    book_id = table.Column<int>(type: "integer", nullable: true),
                    member_id = table.Column<int>(type: "integer", nullable: true),
                    loan_date = table.Column<DateOnly>(type: "date", nullable: false),
                    return_date = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("loan_pkey", x => x.loan_id);
                    table.ForeignKey(
                        name: "loan_book_id_fkey",
                        column: x => x.book_id,
                        principalTable: "book",
                        principalColumn: "book_id");
                    table.ForeignKey(
                        name: "loan_member_id_fkey",
                        column: x => x.member_id,
                        principalTable: "member",
                        principalColumn: "member_id");
                });

            migrationBuilder.CreateIndex(
                name: "book_isbn_key",
                table: "book",
                column: "isbn",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_book_publisher_id",
                table: "book",
                column: "publisher_id");

            migrationBuilder.CreateIndex(
                name: "IX_bookauthor_author_id",
                table: "bookauthor",
                column: "author_id");

            migrationBuilder.CreateIndex(
                name: "IX_bookauthor_book_id",
                table: "bookauthor",
                column: "book_id");

            migrationBuilder.CreateIndex(
                name: "IX_loan_book_id",
                table: "loan",
                column: "book_id");

            migrationBuilder.CreateIndex(
                name: "IX_loan_member_id",
                table: "loan",
                column: "member_id");

            migrationBuilder.CreateIndex(
                name: "member_email_key",
                table: "member",
                column: "email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bookauthor");

            migrationBuilder.DropTable(
                name: "loan");

            migrationBuilder.DropTable(
                name: "author");

            migrationBuilder.DropTable(
                name: "book");

            migrationBuilder.DropTable(
                name: "member");

            migrationBuilder.DropTable(
                name: "publisher");
        }
    }
}
