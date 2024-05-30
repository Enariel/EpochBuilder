// Copyright (c) FuchsFarbe Blazor 2024
// Oliver Conover
// FuchsFarbe Studios
using Epoch.Lib.Models;

namespace Epoch.Lib
{
    /// <summary>
    /// Represents a service that handles articles.
    /// </summary>
    /// <remarks>
    /// This service provides functionality to initialize the storage,
    /// retrieve a list of articles, and add a new article.
    /// </remarks>
    public interface IArticleService
    {
        /// <summary>
        /// Initializes the storage for articles.
        /// </summary>
        /// <returns><see cref="Task"/></returns>
        public Task InitializeAsync();

        /// <summary>
        /// Retrieves a list of articles from the storage.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation and returns a <see cref="List{T}"/> of <see cref="Article"/>s.
        /// If no articles are found in the storage, the task returns null.
        /// </returns>
        public Task<List<Article>> IndexArticlesAsync();

        /// <summary>
        /// Adds a new article to the storage.
        /// </summary>
        /// <param name="article">The article to be added.</param>
        /// <returns>
        /// A task that represents the asynchronous operation and returns the added <see cref="Article"/>.
        /// If the article or storage is null, the task returns null.
        /// </returns>
        public Task<Article> AddArticleAsync(Article article);
    }
}