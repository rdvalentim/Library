﻿// <auto-generated />
using System;
using Library.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Library.Migrations
{
    [DbContext(typeof(LibraryContext))]
    [Migration("20240525191113_MemberModelUpdate")]
    partial class MemberModelUpdate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Library.Models.Author", b =>
                {
                    b.Property<int>("AuthorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("author_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("AuthorId"));

                    b.Property<DateOnly?>("BirthDate")
                        .HasColumnType("date")
                        .HasColumnName("birth_date");

                    b.Property<DateOnly?>("DeathDate")
                        .HasColumnType("date")
                        .HasColumnName("death_date");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("last_name");

                    b.HasKey("AuthorId")
                        .HasName("author_pkey");

                    b.ToTable("author", (string)null);
                });

            modelBuilder.Entity("Library.Models.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("book_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("BookId"));

                    b.Property<string>("Genre")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("genre");

                    b.Property<string>("Isbn")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("character varying(13)")
                        .HasColumnName("isbn");

                    b.Property<int>("NumberOfCopies")
                        .HasColumnType("integer")
                        .HasColumnName("number_of_copies");

                    b.Property<DateOnly?>("PublishDate")
                        .HasColumnType("date")
                        .HasColumnName("publish_date");

                    b.Property<int?>("PublisherId")
                        .HasColumnType("integer")
                        .HasColumnName("publisher_id");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("title");

                    b.HasKey("BookId")
                        .HasName("book_pkey");

                    b.HasIndex("PublisherId");

                    b.HasIndex(new[] { "Isbn" }, "book_isbn_key")
                        .IsUnique();

                    b.ToTable("book", (string)null);
                });

            modelBuilder.Entity("Library.Models.Bookauthor", b =>
                {
                    b.Property<int>("BookAuthorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("book_author_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("BookAuthorId"));

                    b.Property<int?>("AuthorId")
                        .HasColumnType("integer")
                        .HasColumnName("author_id");

                    b.Property<int?>("BookId")
                        .HasColumnType("integer")
                        .HasColumnName("book_id");

                    b.HasKey("BookAuthorId")
                        .HasName("bookauthor_pkey");

                    b.HasIndex("AuthorId");

                    b.HasIndex("BookId");

                    b.ToTable("bookauthor", (string)null);
                });

            modelBuilder.Entity("Library.Models.Loan", b =>
                {
                    b.Property<int>("LoanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("loan_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("LoanId"));

                    b.Property<int?>("BookId")
                        .HasColumnType("integer")
                        .HasColumnName("book_id");

                    b.Property<DateOnly>("LoanDate")
                        .HasColumnType("date")
                        .HasColumnName("loan_date");

                    b.Property<int?>("MemberId")
                        .HasColumnType("integer")
                        .HasColumnName("member_id");

                    b.Property<DateOnly?>("ReturnDate")
                        .HasColumnType("date")
                        .HasColumnName("return_date");

                    b.HasKey("LoanId")
                        .HasName("loan_pkey");

                    b.HasIndex("BookId");

                    b.HasIndex("MemberId");

                    b.ToTable("loan", (string)null);
                });

            modelBuilder.Entity("Library.Models.Member", b =>
                {
                    b.Property<int>("MemberId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("member_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("MemberId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("last_name");

                    b.Property<DateOnly?>("MembershipEndDate")
                        .HasColumnType("date")
                        .HasColumnName("membership_end_date");

                    b.Property<DateOnly>("MembershipStartDate")
                        .HasColumnType("date")
                        .HasColumnName("membership_start_date");

                    b.Property<string>("Phone")
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)")
                        .HasColumnName("phone");

                    b.HasKey("MemberId")
                        .HasName("member_pkey");

                    b.HasIndex(new[] { "Email" }, "member_email_key")
                        .IsUnique();

                    b.ToTable("member", (string)null);
                });

            modelBuilder.Entity("Library.Models.Publisher", b =>
                {
                    b.Property<int>("PublisherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("publisher_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PublisherId"));

                    b.Property<string>("Address")
                        .HasColumnType("text")
                        .HasColumnName("address");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("name");

                    b.Property<string>("Phone")
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)")
                        .HasColumnName("phone");

                    b.HasKey("PublisherId")
                        .HasName("publisher_pkey");

                    b.ToTable("publisher", (string)null);
                });

            modelBuilder.Entity("Library.Models.Book", b =>
                {
                    b.HasOne("Library.Models.Publisher", "Publisher")
                        .WithMany("Books")
                        .HasForeignKey("PublisherId")
                        .HasConstraintName("book_publisher_id_fkey");

                    b.Navigation("Publisher");
                });

            modelBuilder.Entity("Library.Models.Bookauthor", b =>
                {
                    b.HasOne("Library.Models.Author", "Author")
                        .WithMany("Bookauthors")
                        .HasForeignKey("AuthorId")
                        .HasConstraintName("bookauthor_author_id_fkey");

                    b.HasOne("Library.Models.Book", "Book")
                        .WithMany("Bookauthors")
                        .HasForeignKey("BookId")
                        .HasConstraintName("bookauthor_book_id_fkey");

                    b.Navigation("Author");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("Library.Models.Loan", b =>
                {
                    b.HasOne("Library.Models.Book", "Book")
                        .WithMany("Loans")
                        .HasForeignKey("BookId")
                        .HasConstraintName("loan_book_id_fkey");

                    b.HasOne("Library.Models.Member", "Member")
                        .WithMany("Loans")
                        .HasForeignKey("MemberId")
                        .HasConstraintName("loan_member_id_fkey");

                    b.Navigation("Book");

                    b.Navigation("Member");
                });

            modelBuilder.Entity("Library.Models.Author", b =>
                {
                    b.Navigation("Bookauthors");
                });

            modelBuilder.Entity("Library.Models.Book", b =>
                {
                    b.Navigation("Bookauthors");

                    b.Navigation("Loans");
                });

            modelBuilder.Entity("Library.Models.Member", b =>
                {
                    b.Navigation("Loans");
                });

            modelBuilder.Entity("Library.Models.Publisher", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}
