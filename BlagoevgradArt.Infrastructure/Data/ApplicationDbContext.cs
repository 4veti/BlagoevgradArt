﻿using BlagoevgradArt.Infrastructure.Data.Configuration;
using BlagoevgradArt.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlagoevgradArt.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext()
        {
            
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<BaseType> BaseTypes { get; set; } = null!;
        public DbSet<Material> Materials { get; set; } = null!;
        public DbSet<ArtType> ArtTypes { get; set; } = null!;
        public DbSet<Technique> Techniques { get; set; } = null!;
        public DbSet<Genre> Genres { get; set; } = null!;
        public DbSet<Author> Authors { get; set; } = null!;
        public DbSet<Exhibition> Exhibitions { get; set; } = null!;
        public DbSet<AuthorExhibition> AuthorsExhibitions { get; set; } = null!;
        public DbSet<Painting> Paintings { get; set; } = null!;
        public DbSet<Gallery> Galleries { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new BaseTypeConfiguration());
            builder.ApplyConfiguration(new ArtTypeConfiguration());
            builder.ApplyConfiguration(new MaterialConfiguration());
            builder.ApplyConfiguration(new TechniqueConfiguration());
            builder.ApplyConfiguration(new GenreConfiguration());

            builder.ApplyConfiguration(new PaintingConfiguration());

            builder.ApplyConfiguration(new AuthorHelperUserConfiguration());
            builder.ApplyConfiguration(new AuthorConfiguration());

            builder.ApplyConfiguration(new GalleryHelperUserConfiguration());
            builder.ApplyConfiguration(new GalleryConfiguration());

            builder.ApplyConfiguration(new ExhibitionConfiguration());

            builder.ApplyConfiguration(new AuthorExhibitionConfiguration());

            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-3BKCOLA;Database=BlagoevgradArtTests;Trusted_Connection=True;");
            }

            base.OnConfiguring(optionsBuilder);
        }
    }
}
