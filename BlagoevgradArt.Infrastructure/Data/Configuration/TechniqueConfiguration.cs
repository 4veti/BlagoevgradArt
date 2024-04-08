using BlagoevgradArt.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlagoevgradArt.Infrastructure.Data.Configuration
{
    internal class TechniqueConfiguration : IEntityTypeConfiguration<Technique>
    {
        public void Configure(EntityTypeBuilder<Technique> builder)
        {
            SeedData data = new();

            builder.HasData(data.Techniques);
        }
    }
}
