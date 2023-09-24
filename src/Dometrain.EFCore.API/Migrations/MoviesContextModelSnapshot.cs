﻿// <auto-generated />
using System;
using Dometrain.EFCore.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Dometrain.EFCore.API.Migrations
{
    [DbContext(typeof(MoviesContext))]
    partial class MoviesContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Dometrain.EFCore.API.Models.ExternalInformation", b =>
                {
                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<string>("ImdbUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RottenTomatoesUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TmdbUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MovieId");

                    b.ToTable("ExternalInformations");
                });

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
                        .HasMaxLength(256)
                        .HasColumnType("varchar");

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

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("InternetRating")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("MainGenreName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varchar");

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

                    b.HasIndex("MainGenreName");

                    b.ToTable("Pictures", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("Movie");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Dometrain.EFCore.API.Models.CinemaMovie", b =>
                {
                    b.HasBaseType("Dometrain.EFCore.API.Models.Movie");

                    b.Property<decimal>("GrossRevenue")
                        .HasColumnType("decimal(18,2)");

                    b.HasDiscriminator().HasValue("CinemaMovie");
                });

            modelBuilder.Entity("Dometrain.EFCore.API.Models.TelevisionMovie", b =>
                {
                    b.HasBaseType("Dometrain.EFCore.API.Models.Movie");

                    b.Property<string>("ChannelFirstAiredOn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("TelevisionMovie");
                });

            modelBuilder.Entity("Dometrain.EFCore.API.Models.ExternalInformation", b =>
                {
                    b.HasOne("Dometrain.EFCore.API.Models.Movie", "Movie")
                        .WithOne("ExternalInformation")
                        .HasForeignKey("Dometrain.EFCore.API.Models.ExternalInformation", "MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("Dometrain.EFCore.API.Models.Movie", b =>
                {
                    b.HasOne("Dometrain.EFCore.API.Models.Genre", "Genre")
                        .WithMany("Movies")
                        .HasForeignKey("MainGenreName")
                        .HasPrincipalKey("Name")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("Dometrain.EFCore.API.Models.Genre", b =>
                {
                    b.Navigation("Movies");
                });

            modelBuilder.Entity("Dometrain.EFCore.API.Models.Movie", b =>
                {
                    b.Navigation("ExternalInformation");
                });
#pragma warning restore 612, 618
        }
    }
}
