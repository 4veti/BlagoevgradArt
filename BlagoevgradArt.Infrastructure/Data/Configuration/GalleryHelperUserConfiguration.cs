using BlagoevgradArt.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlagoevgradArt.Infrastructure.Data.Configuration
{
    internal class GalleryHelperUserConfiguration : IEntityTypeConfiguration<GalleryHelperUser>
    {
        public void Configure(EntityTypeBuilder<GalleryHelperUser> builder)
        {
            SeedData data = new();

            builder.HasData(new GalleryHelperUser[] { data.GalleryHelperUser });
        }
    }
}
