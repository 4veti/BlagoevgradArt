using BlagoevgradArt.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlagoevgradArt.Infrastructure.Data.Configuration
{
    internal class AuthorHelperUserConfiguration : IEntityTypeConfiguration<AuthorHelperUser>
    {
        public void Configure(EntityTypeBuilder<AuthorHelperUser> builder)
        {
            SeedData data = new();

            builder.HasData(new AuthorHelperUser[] { data.AuthorHelperUser1, data.AuthorHelperUser2 });
        }
    }
}
