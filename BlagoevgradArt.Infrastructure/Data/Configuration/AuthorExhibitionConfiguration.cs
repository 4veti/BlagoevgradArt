using BlagoevgradArt.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlagoevgradArt.Infrastructure.Data.Configuration
{
    public class AuthorExhibitionConfiguration : IEntityTypeConfiguration<AuthorExhibition>
    {
        public void Configure(EntityTypeBuilder<AuthorExhibition> builder)
        {
            builder.HasKey(ae => new { ae.AuthorId, ae.ExhibitionId });
        }
    }
}
