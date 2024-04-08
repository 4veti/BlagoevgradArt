using BlagoevgradArt.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlagoevgradArt.Infrastructure.Data.Configuration
{
    internal class GalleryConfiguration : IEntityTypeConfiguration<Gallery>
    {
        public void Configure(EntityTypeBuilder<Gallery> builder)
        {
            SeedData data = new();

            builder.HasData(new Gallery[] {data.Gallery});
        }
    }
}
