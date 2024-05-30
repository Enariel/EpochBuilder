// Copyright (c) FuchsFarbe Blazor 2024
// Oliver Conover
// FuchsFarbe Studios
using Epoch.Lib.Models;

namespace Epoch.Lib
{
    [Serializable]
    public class ArticleStore
    {
        public List<Article> Articles { get; set; } = new List<Article>();
    }
}