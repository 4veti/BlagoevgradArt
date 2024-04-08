using BlagoevgradArt.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlagoevgradArt.Infrastructure.Data.Configuration
{
    internal class ArtTypeConfiguration : IEntityTypeConfiguration<ArtType>
    {
        public void Configure(EntityTypeBuilder<ArtType> builder)
        {
            SeedData data = new();

            builder.HasData(data.ArtTypes);
        }
    }
}
