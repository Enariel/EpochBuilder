// Copyright (c) FuchsFarbe Blazor 2024
// Oliver Conover
// FuchsFarbe Studios
using Epoch.Lib.Models;

namespace Epoch.Lib
{
    /// <summary>
    /// Provides methods to retrieve and manage tags.
    /// </summary>
    public interface ITagService
    {
        /// <summary>
        /// Retrieves a list of all tags.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains a list of tags.
        /// </returns>
        public Task<List<Tag>> IndexTagsAsync();
    }
}