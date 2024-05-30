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

        /// <inheritdoc />
        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);
        }
    }
}