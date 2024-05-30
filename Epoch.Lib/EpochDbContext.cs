// Copyright (c) FuchsFarbe Blazor 2024
// Oliver Conover
// FuchsFarbe Studios
using Epoch.Lib.Models;
using Microsoft.EntityFrameworkCore;

namespace Epoch.Lib
{
    public class EpochDbContext : DbContext
    {
        /// <inheritdoc />
        public EpochDbContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<World> Worlds { get; set; }
        public virtual DbSet<WorldTag> WorldTags { get; set; }
        public virtual DbSet<WorldArticle> WorldArticles { get; set; }
        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<ArticleTag> ArticleTags { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }

        /// <inheritdoc />
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<WorldTag>(e =>
            {
                e.HasKey(wt => new { wt.TagId, wt.WorldId });
                e.HasOne(wt => wt.World)
                 .WithMany(w => w.WorldTags)
                 .HasForeignKey(wt => wt.WorldId)
                 .OnDelete(DeleteBehavior.Cascade);

                e.HasOne(wt => wt.Tag)
                 .WithMany()
                 .HasForeignKey(wt => wt.TagId)
                 .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<ArticleTag>(e =>
            {
                e.HasKey(at => new { at.TagId, at.ArticleId });
                e.HasOne(at => at.Tag)
                 .WithMany()
                 .HasForeignKey(at => at.ArticleId)
                 .OnDelete(DeleteBehavior.Cascade);

                e.HasOne(at => at.Tag)
                 .WithMany()
                 .HasForeignKey(at => at.TagId)
                 .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<WorldArticle>(e =>
            {
                e.HasKey(wa => new { wa.WorldId, wa.ArticleId });

                e.HasOne(wa => wa.World)
                 .WithMany(w => w.WorldArticles)
                 .HasForeignKey(wa => wa.WorldId)
                 .OnDelete(DeleteBehavior.Cascade);

                e.HasOne(wa => wa.Article)
                 .WithMany(a => a.WorldArticles)
                 .HasForeignKey(wa => wa.ArticleId)
                 .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<World>(e =>
            {
                e.HasKey(w => w.WorldId);
                e.Property(w => w.WorldId)
                 .ValueGeneratedOnAdd();
                e.Property(w => w.WorldName).HasMaxLength(128);
                e.Property(w => w.Description).HasMaxLength(2000);
                e.Property(w => w.Excerpt).HasMaxLength(255);
            });

            builder.Entity<Article>(e =>
            {
                e.HasKey(a => a.ArticleId);
                e.Property(a => a.ArticleId)
                 .ValueGeneratedOnAdd();
                e.Property(a => a.Title)
                 .HasMaxLength(128);
                e.Property(a => a.SubTitle)
                 .HasMaxLength(180);
                e.Property(a => a.Content)
                 .HasMaxLength(5000);
                e.Property(a => a.Credits)
                 .HasMaxLength(255);
                e.Property(a => a.Footnotes)
                 .HasMaxLength(255);
                e.Property(a => a.AuthorsNotes)
                 .HasMaxLength(255);
                e.Property(a => a.SidebarBottom)
                 .HasMaxLength(255);
                e.Property(a => a.SidebarTop)
                 .HasMaxLength(255);
                e.Property(a => a.SidebarTopContent)
                 .HasMaxLength(255);
                e.Property(a => a.SidebarBottomContent)
                 .HasMaxLength(255);
                e.OwnsOne(w => w.Prefs);
            });

            builder.Entity<Tag>(e =>
            {
                e.HasKey(t => t.TagId);
                e.Property(t => t.TagId)
                 .ValueGeneratedOnAdd();
                e.Property(w => w.Description)
                 .HasMaxLength(128)
                 .IsRequired();
            });
            base.OnModelCreating(builder);
        }
    }
}