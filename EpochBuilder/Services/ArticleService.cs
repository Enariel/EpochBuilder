// Copyright (c) FuchsFarbe Blazor 2024
// Oliver Conover
// FuchsFarbe Studios
using Blazored.LocalStorage;
using Epoch.Lib;
using Epoch.Lib.Models;

namespace EpochBuilder.Services
{
    public class ArticleService : IArticleService
    {
        private readonly ILogger<IArticleService> _logger;
        private readonly ILocalStorageService _storage;

        public ArticleService(ILogger<ArticleService> logger, ILocalStorageService storage)
        {
            _logger = logger;
            _storage = storage;
        }

        public async Task InitializeAsync()
        {
            var store = await _storage.GetItemAsync<ArticleStore>(StoreKeys.ArticleStoreKey);
            if (store != null)
                return;

            store = new ArticleStore();
            await _storage.SetItemAsync(StoreKeys.ArticleStoreKey, store);
        }

        public async Task<List<Article>> IndexArticlesAsync()
        {
            var articles = new List<Article>();
            var articleStore = await _storage.GetItemAsync<ArticleStore>(StoreKeys.ArticleStoreKey);
            if (articleStore != null)
                return articles = articleStore.Articles;
            return articles;
        }
    }

    public interface IArticleService
    {
        public Task InitializeAsync();
        public Task<List<Article>> IndexArticlesAsync();
    }
}