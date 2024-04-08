using BlagoevgradArt.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlagoevgradArt.Infrastructure.Data.Configuration
{
    internal class BaseTypeConfiguration : IEntityTypeConfiguration<BaseType>
    {
        public void Configure(EntityTypeBuilder<BaseType> builder)
        {
            SeedData data = new();

            builder.HasData(data.BaseTypes);
        }
    }
}
