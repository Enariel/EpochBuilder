// Copyright (c) FuchsFarbe Blazor 2024
// Oliver Conover
// FuchsFarbe Studios
namespace Epoch.Lib.Models
{
    [Serializable]
    public class ArticleTag
    {
        public long TagId { get; set; }
        public Guid ArticleId { get; set; }
        public virtual Tag Tag { get; set; }
        public virtual Article Article { get; set; }
    }
}