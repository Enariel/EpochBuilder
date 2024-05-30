// Copyright (c) FuchsFarbe Blazor 2024
// Oliver Conover
// FuchsFarbe Studios
using Microsoft.JSInterop;

namespace EpochBuilder.Services
{
    /// <summary>
    /// Provides access to the browser database.
    /// </summary>
    public class BrowserDbAccessor : IAsyncDisposable
    {
        private Lazy<IJSObjectReference> _jsRef = new Lazy<IJSObjectReference>();
        private readonly IJSRuntime _jsRuntime;
        private readonly IConfiguration _configuration;
        private string dbName;
        private int dbVersion;

        public BrowserDbAccessor(IJSRuntime runtime, IConfiguration configuration)
        {
            _jsRuntime = runtime;
            _configuration = configuration;
            dbName = _configuration["IndexDb:DbName"];
            dbVersion = int.Parse(_configuration["IndexDb:Version"]);
        }

        /// <summary>
        /// Initializes the browser database by invoking the 'initialize' JavaScript function with the specified database name and version.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task InitializeAsync()
        {
            await WaitForReference();
            await _jsRef.Value.InvokeVoidAsync("initialize", dbName, dbVersion);
        }

        /// <summary>
        /// Retrieves the value of an item in the specified collection from the browser database.
        /// </summary>
        /// <typeparam name="T">The type of the value to retrieve.</typeparam>
        /// <param name="collectionName">The name of the collection.</param>
        /// <param name="id">The identifier of the item.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation.</returns>
        public async Task<T> GetValueAsync<T>(string collectionName, int id)
        {
            await WaitForReference();
            var result = await _jsRef.Value.InvokeAsync<T>("get", collectionName, id, dbName, dbVersion);
            return result;
        }

        /// <summary>
        /// Sets the value of an item in the specified collection in the browser database.
        /// </summary>
        /// <typeparam name="T">The type of the value to set.</typeparam>
        /// <param name="collectionName">The name of the collection.</param>
        /// <param name="value">The value to set.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task SetValueAsync<T>(string collectionName, T value)
        {
            await WaitForReference();
            await _jsRef.Value.InvokeVoidAsync("set", collectionName, value, dbName, dbVersion);
        }

        private async Task WaitForReference()
        {
            if (_jsRef.IsValueCreated is false)
                _jsRef = new Lazy<IJSObjectReference>(await _jsRuntime.InvokeAsync<IJSObjectReference>("import", "/js/app.js"));
        }

        /// <inheritdoc />
        public async ValueTask DisposeAsync()
        {
            if (_jsRef.IsValueCreated)
                await _jsRef.Value.DisposeAsync();
        }
    }
}