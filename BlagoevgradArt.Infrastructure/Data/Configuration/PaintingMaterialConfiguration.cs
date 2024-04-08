using BlagoevgradArt.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlagoevgradArt.Infrastructure.Data.Configuration
{
    internal class PaintingMaterialConfiguration : IEntityTypeConfiguration<PaintingMaterial>
    {
        public void Configure(EntityTypeBuilder<PaintingMaterial> builder)
        {
            builder.HasKey(pm => new {pm.PaintingId, pm.MaterialId});

            SeedData data = new();

            builder.HasData(data.PaintingsMaterials);
        }
    }
}
