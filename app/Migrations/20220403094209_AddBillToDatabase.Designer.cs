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
    [Migration("20220403094209_AddBillToDatabase")]
    partial class AddBillToDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("app.Models.Author", b =>
                {
                    b.Property<int>("author_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("author_id"), 1L, 1);

                    b.Property<string>("author_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("author_id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("app.Models.Bill", b =>
                {
                    b.Property<int>("bill_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("bill_id"), 1L, 1);

                    b.Property<string>("due_date")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("issue_date")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("bill_id");

                    b.ToTable("Bills");
                });

            modelBuilder.Entity("app.Models.Book", b =>
                {
                    b.Property<int>("book_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("book_id"), 1L, 1);

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("PublisherId")
                        .HasColumnType("int");

                    b.Property<int>("actual_stock")
                        .HasColumnType("int");

                    b.Property<int>("author_id")
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

                    b.HasIndex("AuthorId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("PublisherId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("app.Models.Category", b =>
                {
                    b.Property<int>("category_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("category_id"), 1L, 1);

                    b.Property<string>("category_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("category_id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("app.Models.Publisher", b =>
                {
                    b.Property<int>("publisher_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("publisher_id"), 1L, 1);

                    b.Property<string>("publisher_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("publisher_id");

                    b.ToTable("Publisher");
                });

            modelBuilder.Entity("BillBook", b =>
                {
                    b.Property<int>("Billsbill_id")
                        .HasColumnType("int");

                    b.Property<int>("Booksbook_id")
                        .HasColumnType("int");

                    b.HasKey("Billsbill_id", "Booksbook_id");

                    b.HasIndex("Booksbook_id");

                    b.ToTable("BillBook");
                });

            modelBuilder.Entity("app.Models.Book", b =>
                {
                    b.HasOne("app.Models.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("app.Models.Category", "Category")
                        .WithMany("Books")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("app.Models.Publisher", "Publisher")
                        .WithMany("Books")
                        .HasForeignKey("PublisherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Category");

                    b.Navigation("Publisher");
                });

            modelBuilder.Entity("BillBook", b =>
                {
                    b.HasOne("app.Models.Bill", null)
                        .WithMany()
                        .HasForeignKey("Billsbill_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("app.Models.Book", null)
                        .WithMany()
                        .HasForeignKey("Booksbook_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("app.Models.Author", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("app.Models.Category", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("app.Models.Publisher", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}
