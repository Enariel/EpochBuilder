// Copyright (c) FuchsFarbe Blazor 2024
// Oliver Conover
// FuchsFarbe Studios
using Epoch.Lib.Models;
using Microsoft.EntityFrameworkCore;

namespace Epoch.Lib
{
    public class EpochDbContext : DbContext
    {
        private string _conn;

        #region Constructors

        /// <inheritdoc />
        protected EpochDbContext() { }

        /// <inheritdoc />
        protected EpochDbContext(string conn) => _conn = conn;

        /// <inheritdoc />
        public EpochDbContext(DbContextOptions options) : base(options) { }

        #endregion

        public virtual DbSet<World> Worlds { get; set; }

        /// <inheritdoc />
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(_conn);
        }

        /// <inheritdoc />
        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);
        }
    }
}