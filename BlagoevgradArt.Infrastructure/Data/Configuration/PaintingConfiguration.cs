using BlagoevgradArt.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlagoevgradArt.Infrastructure.Data.Configuration
{
    internal class PaintingConfiguration : IEntityTypeConfiguration<Painting>
    {
        public void Configure(EntityTypeBuilder<Painting> builder)
        {
            SeedData data = new();

            builder.HasData(data.Paintings);
        }
    }
}
