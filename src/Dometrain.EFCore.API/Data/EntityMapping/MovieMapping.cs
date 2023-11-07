using Dometrain.EFCore.API.Data.ValueConverters;
using Dometrain.EFCore.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dometrain.EFCore.API.Data.EntityMapping;

public class MovieMapping : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder
            .ToTable("Pictures")
            .UseTphMappingStrategy()
            .HasQueryFilter(movie => movie.ReleaseDate > new DateTime(1990,1,1))
            .HasKey(movie => movie.Identifier);

        builder
            .HasAlternateKey(movie => new { movie.Title, movie.ReleaseDate });

        builder.Property(movie => movie.Title)
            .HasColumnType("varchar")
            .HasMaxLength(128)
            .IsRequired();

        builder.Property(movie => movie.ReleaseDate)
            .HasColumnType("char(8)")
            .HasConversion(new DateTimeToChar8Converter());

        builder.Property(movie => movie.Synopsis)
            .HasColumnType("varchar(max)")
            .HasColumnName("Plot");

        builder.Property(movie => movie.MainGenreName)
            .HasMaxLength(256)
            .HasColumnType("varchar");

        builder
            .HasOne(movie => movie.Genre)
            .WithMany(genre => genre.Movies)
            .HasPrincipalKey(genre => genre.Name)
            .HasForeignKey(movie => movie.MainGenreName);

        // builder
        //     .OwnsOne(movie => movie.Director)
        //     .ToTable("Pictures_Directors"); 
        //
        // builder
        //     .OwnsMany(movie => movie.Actors);
    }
}

public class CinemaMovieMapping : IEntityTypeConfiguration<CinemaMovie>
{
    public void Configure(EntityTypeBuilder<CinemaMovie> builder)
    {
    }
}

public class TelevisionMovieMapping : IEntityTypeConfiguration<TelevisionMovie>
{
    public void Configure(EntityTypeBuilder<TelevisionMovie> builder)
    {
    }
}