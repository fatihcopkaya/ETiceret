﻿// <auto-generated />
using System;
using DataAccessLayer.Concrete.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccessLayer.Migrations
{
    [DbContext(typeof(EticaretContext))]
    [Migration("20230304155738_mig-adress2")]
    partial class migadress2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("EntityLayer.Concrete.Adress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AdressDetail")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("GuId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("Zip")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Adresses");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("FileCode")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("GuId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsActived")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Total")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("GuId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsActived")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("OrderBy")
                        .HasColumnType("int");

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.Property<string>("SlugUrl")
                        .HasColumnType("longtext");

                    b.Property<string>("Title")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CommentUsername")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("GuId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsActived")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Document", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("DocumentFolderName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("DocumentName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("DocumentSize")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("DocumentType")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("DocumentUnique")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("GuId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Image_Url")
                        .HasColumnType("longtext");

                    b.Property<string>("Video_Url")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("CartId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("GuId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsActived")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("OrderBy")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<string>("SlugUrl")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("UserId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("EntityLayer.Concrete.ProductPhoto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("FileCode")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("GuId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("Index")
                        .HasColumnType("int");

                    b.Property<bool>("IsActived")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId")
                        .IsUnique();

                    b.ToTable("ProductPhotos");
                });

            modelBuilder.Entity("EntityLayer.Concrete.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("GuId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsActived")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("SecretKey")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Token")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("TokenExpiryDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "admin@admin.com",
                            FirstName = "Admin",
                            GuId = "4ca4e2b654894f4db57685007068d6be",
                            IsActived = true,
                            LastName = "Admin",
                            PasswordHash = "37faeb21348abc0c4ea7d4dea94f06320d3e70d967bf628514e755a470c220690232c08503bd6edcd8adbdc23dc9dcd7e2540763ab2fc895a6bfc1aa74235ae6",
                            Role = "Admin",
                            SecretKey = "0ecefd57e8f647f39c807af4280409d83/4/202365738PM",
                            Token = "",
                            TokenExpiryDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("EntityLayer.Concrete.Adress", b =>
                {
                    b.HasOne("EntityLayer.Concrete.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Cart", b =>
                {
                    b.HasOne("EntityLayer.Concrete.User", "User")
                        .WithMany("Cart")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Category", b =>
                {
                    b.HasOne("EntityLayer.Concrete.Category", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Comment", b =>
                {
                    b.HasOne("EntityLayer.Concrete.Product", "Product")
                        .WithMany("Comment")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityLayer.Concrete.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Product", b =>
                {
                    b.HasOne("EntityLayer.Concrete.Cart", null)
                        .WithMany("Product")
                        .HasForeignKey("CartId");

                    b.HasOne("EntityLayer.Concrete.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityLayer.Concrete.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("User");
                });

            modelBuilder.Entity("EntityLayer.Concrete.ProductPhoto", b =>
                {
                    b.HasOne("EntityLayer.Concrete.Product", "Product")
                        .WithOne("ProductPhoto")
                        .HasForeignKey("EntityLayer.Concrete.ProductPhoto", "ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Cart", b =>
                {
                    b.Navigation("Product");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Category", b =>
                {
                    b.Navigation("Children");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Product", b =>
                {
                    b.Navigation("Comment");

                    b.Navigation("ProductPhoto")
                        .IsRequired();
                });

            modelBuilder.Entity("EntityLayer.Concrete.User", b =>
                {
                    b.Navigation("Cart");
                });
#pragma warning restore 612, 618
        }
    }
}
