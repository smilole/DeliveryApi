﻿// <auto-generated />
using System;
using DeliveryApi.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DeliveryApi.Migrations.BasketDb
{
    [DbContext(typeof(BasketDbContext))]
    [Migration("20231107134259_AddKeyForDish")]
    partial class AddKeyForDish
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Delivery.Api.DishBasketDto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("amount")
                        .HasColumnType("integer");

                    b.Property<string>("image")
                        .HasColumnType("text");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("price")
                        .HasColumnType("double precision");

                    b.Property<double>("totalPrice")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("Baskets");
                });

            modelBuilder.Entity("DeliveryApi.Models.DishInBasketModel", b =>
                {
                    b.Property<Guid>("DishId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("DishId");

                    b.ToTable("DishInBasket");
                });
#pragma warning restore 612, 618
        }
    }
}
