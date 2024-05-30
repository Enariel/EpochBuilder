// Copyright (c) FuchsFarbe Blazor 2024
// Oliver Conover
// FuchsFarbe Studios
using Blazored.LocalStorage;
using Epoch.Lib;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace EpochBuilder.Services
{
    public class DataService
    {
        private readonly ILogger<DataService> _logger;
        private readonly ILocalStorageService _storage;
        private readonly EpochDbContext _ctx;

        public DataService(ILogger<DataService> logger, EpochDbContext ctx, ILocalStorageService storage)
        {
            _logger = logger;
            _ctx = ctx;
            _storage = storage;
        }

        public async Task UpdateDataAsync(SaveData data)
        {
            var worlds = await _ctx.Worlds
                                   .Include(x=>x.WorldArticles)
                                   .ThenInclude(x=>x.Article)
                                   .ThenInclude(x=>x.ArticleTags)
                                   .Include(x=>x.WorldTags)
                                   .Include(x=>x.Time)
                                   .Include(x=>x.Options)
                                   .Include(x=>x.Home)
                                   .ToListAsync();
            var tags = await _ctx.Tags.ToListAsync();
            data.Tags = tags;
            data.Worlds = worlds;
            _logger.LogInformation("Data updated...");
            await Task.CompletedTask;
        }

        public async Task SaveDataAsync(SaveData data)
        {
            string json = "";
            json = JsonSerializer.Serialize(data, new JsonSerializerOptions
                                                  {
                                                      AllowTrailingCommas = true,
                                                      IgnoreReadOnlyFields = true,
                                                      IgnoreReadOnlyProperties = true,
                                                      WriteIndented = true,
                                                      ReferenceHandler = ReferenceHandler.Preserve
                                                  });
            await _storage.SetItemAsStringAsync(nameof(data), json);
            _logger.LogInformation("Saved json string: " + json);
        }

        public async Task<SaveData> RestoreDataAsync(string data)
        {
            string json = await _storage.GetItemAsStringAsync(nameof(data));
            _logger.LogInformation("Loaded json string: " + json);
            if (string.IsNullOrEmpty(json))
                return new SaveData();
            SaveData saveData = JsonSerializer.Deserialize<SaveData>(json);
            return saveData;
        }
    }
}