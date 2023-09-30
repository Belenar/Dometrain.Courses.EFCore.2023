using Dometrain.EFCore.API.Data.ValueGenerators;
using Dometrain.EFCore.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dometrain.EFCore.API.Data.EntityMapping;

public class GenreMapping : IEntityTypeConfiguration<Genre>
{
    public void Configure(EntityTypeBuilder<Genre> builder)
    {
        builder.Property<DateTime>("CreatedDate")
            .HasColumnName("CreatedAt")
            .HasValueGenerator<CreatedDateGenerator>();
        
        builder.Property(g => g.Name)
            .HasMaxLength(256)
            .HasColumnType("varchar");
        
        builder.Property(g => g.Description)
            .HasMaxLength(1024)
            .HasColumnType("varchar");

        builder
            .Property<bool>("Deleted")
            .HasDefaultValue(false);

        builder
            .HasQueryFilter(g => EF.Property<bool>(g, "Deleted") == false)
            .HasAlternateKey(g => g.Name);
    }
}