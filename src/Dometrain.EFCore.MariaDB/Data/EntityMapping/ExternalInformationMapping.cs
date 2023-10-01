using Dometrain.EFCore.MariaDB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dometrain.EFCore.MariaDB.Data.EntityMapping;

public class ExternalInformationMapping : IEntityTypeConfiguration<ExternalInformation>
{
    public void Configure(EntityTypeBuilder<ExternalInformation> builder)
    {
        builder.HasKey(info => info.MovieId);

        builder.HasOne(info => info.Movie)
            .WithOne(movie => movie.ExternalInformation);
    }
}