// Copyright (c) FuchsFarbe Blazor 2024
// Oliver Conover
// FuchsFarbe Studios
using Epoch.Lib;
using Epoch.Lib.Models;
using Microsoft.EntityFrameworkCore;

namespace EpochBuilder.Services
{
    /// <summary>
    /// Represents a service for managing tags.
    /// </summary>
    public class TagService : ITagService
    {
        private readonly ILogger<ITagService> _logger;
        private readonly EpochDbContext _ctx;

        public TagService(EpochDbContext ctx, ILogger<TagService> logger)
        {
            _ctx = ctx;
            _logger = logger;
        }

        /// <summary>
        /// Retrieves a list of all tags asynchronously.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains a list of tags.
        /// </returns>
        public async Task<List<Tag>> IndexTagsAsync()
        {
            var tags = await _ctx.Tags.ToListAsync();
            return tags;
        }
    }

}