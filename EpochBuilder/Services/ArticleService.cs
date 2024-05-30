// Copyright (c) FuchsFarbe Blazor 2024
// Oliver Conover
// FuchsFarbe Studios
using Blazored.LocalStorage;
using Epoch.Lib;
using Epoch.Lib.Models;

namespace EpochBuilder.Services
{
    /// <summary>
    /// Represents a service that handles articles.
    /// </summary>
    public class ArticleService : IArticleService
    {
        private readonly ILogger<IArticleService> _logger;
        private readonly ILocalStorageService _storage;

        public ArticleService(ILogger<ArticleService> logger, ILocalStorageService storage)
        {
            _logger = logger;
            _storage = storage;
        }

        /// <inheritdoc />
        public async Task InitializeAsync()
        {
            var store = await _storage.GetItemAsync<ArticleStore>(StoreKeys.ArticleStoreKey);
            if (store != null)
                return;

            store = new ArticleStore();
            await _storage.SetItemAsync(StoreKeys.ArticleStoreKey, store);
        }

        /// <inheritdoc />
        public async Task<List<Article>> IndexArticlesAsync()
        {
            var articleStore = await _storage.GetItemAsync<ArticleStore>(StoreKeys.ArticleStoreKey);
            if (articleStore != null)
                return articleStore.Articles;
            return null;
        }

        /// <inheritdoc />
        public async Task<Article> AddArticleAsync(Article article)
        {
            var store = await _storage.GetItemAsync<ArticleStore>(StoreKeys.ArticleStoreKey);
            if (store == null || article == null)
                return null;
            if (store.Articles.Any(x => x.ArticleId == article.ArticleId))
                article.ArticleId = Guid.NewGuid();
            store.Articles.Add(article);
            await _storage.SetItemAsync(StoreKeys.ArticleStoreKey, store);
            return article;
        }
    }

}