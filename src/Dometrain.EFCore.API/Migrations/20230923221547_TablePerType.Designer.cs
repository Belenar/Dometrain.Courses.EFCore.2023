﻿// <auto-generated />
using System;
using Dometrain.EFCore.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Dometrain.EFCore.API.Migrations
{
    [DbContext(typeof(MoviesContext))]
    [Migration("20230923221547_TablePerType")]
    partial class TablePerType
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Dometrain.EFCore.API.Models.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedAt");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("Dometrain.EFCore.API.Models.Movie", b =>
                {
                    b.Property<int>("Identifier")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Identifier"));

                    b.Property<int>("AgeRating")
                        .HasColumnType("int");

                    b.Property<decimal>("InternetRating")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("MainGenreId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("date");

                    b.Property<string>("Synopsis")
                        .HasColumnType("varchar(max)")
                        .HasColumnName("Plot");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varchar");

                    b.HasKey("Identifier");

                    b.HasIndex("MainGenreId");

                    b.ToTable("Pictures", (string)null);

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("Dometrain.EFCore.API.Models.CinemaMovie", b =>
                {
                    b.HasBaseType("Dometrain.EFCore.API.Models.Movie");

                    b.Property<decimal>("GrossRevenue")
                        .HasColumnType("decimal(18,2)");

                    b.ToTable("CinemaMovie", (string)null);
                });

            modelBuilder.Entity("Dometrain.EFCore.API.Models.TelevisionMovie", b =>
                {
                    b.HasBaseType("Dometrain.EFCore.API.Models.Movie");

                    b.Property<string>("ChannelFirstAiredOn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("TelevisionMovie", (string)null);
                });

            modelBuilder.Entity("Dometrain.EFCore.API.Models.Movie", b =>
                {
                    b.HasOne("Dometrain.EFCore.API.Models.Genre", "Genre")
                        .WithMany("Movies")
                        .HasForeignKey("MainGenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("Dometrain.EFCore.API.Models.CinemaMovie", b =>
                {
                    b.HasOne("Dometrain.EFCore.API.Models.Movie", null)
                        .WithOne()
                        .HasForeignKey("Dometrain.EFCore.API.Models.CinemaMovie", "Identifier")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Dometrain.EFCore.API.Models.TelevisionMovie", b =>
                {
                    b.HasOne("Dometrain.EFCore.API.Models.Movie", null)
                        .WithOne()
                        .HasForeignKey("Dometrain.EFCore.API.Models.TelevisionMovie", "Identifier")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Dometrain.EFCore.API.Models.Genre", b =>
                {
                    b.Navigation("Movies");
                });
#pragma warning restore 612, 618
        }
    }
}
