// Copyright (c) FuchsFarbe Blazor 2024
// Oliver Conover
// FuchsFarbe Studios
using System.Text.Json.Serialization;

namespace Epoch.Lib.Models
{
    [Serializable]
    public class ArticleTag
    {
        public long TagId { get; set; }
        public Guid ArticleId { get; set; }
        [JsonIgnore]
        public virtual Tag Tag { get; set; }
        [JsonIgnore]
        public virtual Article Article { get; set; }
    }
}