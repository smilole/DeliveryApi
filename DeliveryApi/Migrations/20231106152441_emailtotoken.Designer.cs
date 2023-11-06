﻿// <auto-generated />
using System;
using DeliveryApi.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DeliveryApi.Migrations
{
    [DbContext(typeof(UserDbContext))]
    [Migration("20231106152441_emailtotoken")]
    partial class emailtotoken
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Delivery.Api.Classes.UserRegisterModel", b =>
                {
                    b.Property<string>("email")
                        .HasColumnType("text");

                    b.Property<DateOnly?>("birthDate")
                        .HasColumnType("date");

                    b.Property<string>("fullName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("gender")
                        .HasColumnType("integer");

                    b.Property<Guid>("id")
                        .HasColumnType("uuid");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("phoneNumber")
                        .HasColumnType("text");

                    b.HasKey("email");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DeliveryApi.Models.EmailToTokenModel", b =>
                {
                    b.Property<string>("email")
                        .HasColumnType("text");

                    b.Property<string>("token")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("email");

                    b.ToTable("EmailToTokens");
                });
#pragma warning restore 612, 618
        }
    }
}
