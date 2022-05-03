﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using library.Data;

#nullable disable

namespace library.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220328122222_AddBookToDatabase")]
    partial class AddBookToDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("app.Models.Book", b =>
                {
                    b.Property<int>("book_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("book_id"), 1L, 1);

                    b.Property<int>("actual_stock")
                        .HasColumnType("int");

                    b.Property<string>("author_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("book_cost")
                        .HasColumnType("real");

                    b.Property<string>("book_description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("book_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("current_stock")
                        .HasColumnType("int");

                    b.Property<string>("edition")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("genre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("img_url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("language")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("no_of_pages")
                        .HasColumnType("int");

                    b.Property<string>("publish_date")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("publisher_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("book_id");

                    b.ToTable("Books");
                });
#pragma warning restore 612, 618
        }
    }
}
