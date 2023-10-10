﻿// <auto-generated />
using System;
using LibaryManagmentSystemAPI;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LibaryManagmentSystemAPI.Migrations
{
    [DbContext(typeof(LibraryDbContext))]
    [Migration("20231009072058_update2")]
    partial class update2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LibaryManagmentSystemAPI.Models.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookId"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<int>("PublicationYear")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BookId");

                    b.ToTable("books");
                });

            modelBuilder.Entity("LibaryManagmentSystemAPI.Models.BorrowingTransaction", b =>
                {
                    b.Property<int>("BorrowingTransactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BorrowingTransactionId"));

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<DateTime>("BorrowDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PatronId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ReturnDate")
                        .HasColumnType("datetime2");

                    b.HasKey("BorrowingTransactionId");

                    b.HasIndex("BookId");

                    b.HasIndex("PatronId");

                    b.ToTable("borrowingTransactions");
                });

            modelBuilder.Entity("LibaryManagmentSystemAPI.Models.Patron", b =>
                {
                    b.Property<int>("PatronId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PatronId"));

                    b.Property<int>("Age")
                        .HasMaxLength(200)
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PatronId");

                    b.ToTable("patrons");
                });

            modelBuilder.Entity("LibaryManagmentSystemAPI.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("users");
                });

            modelBuilder.Entity("LibaryManagmentSystemAPI.Models.BorrowingTransaction", b =>
                {
                    b.HasOne("LibaryManagmentSystemAPI.Models.Book", "Book")
                        .WithMany("BorrowingTransactions")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibaryManagmentSystemAPI.Models.Patron", "Patron")
                        .WithMany("BorrowingTransactions")
                        .HasForeignKey("PatronId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Patron");
                });

            modelBuilder.Entity("LibaryManagmentSystemAPI.Models.Book", b =>
                {
                    b.Navigation("BorrowingTransactions");
                });

            modelBuilder.Entity("LibaryManagmentSystemAPI.Models.Patron", b =>
                {
                    b.Navigation("BorrowingTransactions");
                });
#pragma warning restore 612, 618
        }
    }
}
