using Dometrain.EFCore.Tenants.QueryFilter.Data.ValueGenerators;
using Dometrain.EFCore.Tenants.QueryFilter.Models;
using Dometrain.EFCore.Tenants.QueryFilter.Tenants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dometrain.EFCore.Tenants.QueryFilter.Data.EntityMapping;

public class GenreMapping : TenantAwareMapping<Genre>
{
    public GenreMapping(MoviesContext context) : base(context)
    { }

    public override void ConfigureEntity(EntityTypeBuilder<Genre> builder)
    {
        builder.Property<DateTime>("CreatedDate")
            .HasColumnName("CreatedAt")
            .HasValueGenerator<CreatedDateGenerator>();
    }
}