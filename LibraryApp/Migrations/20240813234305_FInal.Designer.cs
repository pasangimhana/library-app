﻿// <auto-generated />
using LibraryApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LibraryApp.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240813234305_FInal")]
    partial class FInal
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("LibraryApp.Models.GuestMessage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Date")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Guest_Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("GuestMessage");
                });

            modelBuilder.Entity("LibraryApp.Models.Inventory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Inventory");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            Author = "F. Scott Fitzgerald",
                            ISBN = "9780743273565",
                            Name = "The Great Gatsby",
                            Status = "Available",
                            Type = "Book"
                        },
                        new
                        {
                            Id = -2,
                            Author = "Harper Lee",
                            ISBN = "9780061120084",
                            Name = "To Kill a Mockingbird",
                            Status = "Available",
                            Type = "Book"
                        },
                        new
                        {
                            Id = -3,
                            Author = "George Orwell",
                            ISBN = "9780451524935",
                            Name = "1984",
                            Status = "Available",
                            Type = "Book"
                        },
                        new
                        {
                            Id = -4,
                            Author = "Jane Austen",
                            ISBN = "9780141439518",
                            Name = "Pride and Prejudice",
                            Status = "Available",
                            Type = "Book"
                        },
                        new
                        {
                            Id = -5,
                            Author = "Herman Melville",
                            ISBN = "9781503280786",
                            Name = "Moby Dick",
                            Status = "Available",
                            Type = "Book"
                        });
                });

            modelBuilder.Entity("LibraryApp.Models.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Guest_Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Item_Id")
                        .HasColumnType("int");

                    b.Property<string>("ReservationMessage")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Reservation_Date")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Reservation");
                });

            modelBuilder.Entity("LibraryApp.Models.Return", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Guest_Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Item_Id")
                        .HasColumnType("int");

                    b.Property<string>("ReturnMessage")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Return_Date")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Return");
                });

            modelBuilder.Entity("LibraryApp.Models.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Guest_Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Item_Id")
                        .HasColumnType("int");

                    b.Property<string>("Reference_Date")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Transaction_Type")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Transaction");
                });

            modelBuilder.Entity("LibraryApp.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Active")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Contact")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            Active = true,
                            Contact = "1234567890",
                            Email = "admin@admin.com",
                            Name = "Admin",
                            Password = "admin",
                            Username = "admin"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
