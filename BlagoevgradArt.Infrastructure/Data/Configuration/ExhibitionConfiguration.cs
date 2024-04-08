using BlagoevgradArt.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlagoevgradArt.Infrastructure.Data.Configuration
{
    public class ExhibitionConfiguration : IEntityTypeConfiguration<Exhibition>
    {
        public void Configure(EntityTypeBuilder<Exhibition> builder)
        {
            builder.HasMany(e => e.AuthorExhibitions)
                .WithOne(ae => ae.Exhibition)
                .HasForeignKey(ae => ae.ExhibitionId)
                .OnDelete(DeleteBehavior.Restrict);

            SeedData data = new();
            data.Exhibitions[0].Paintings.Add(data.Paintings[0]);

            builder.HasData(data.Exhibitions);
        }
    }
}
