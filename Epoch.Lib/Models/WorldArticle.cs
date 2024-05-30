// Copyright (c) FuchsFarbe Blazor 2024
// Oliver Conover
// FuchsFarbe Studios
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace Epoch.Lib.Models
{
    [Serializable]
    public class WorldArticle
    {
        [XmlElement("World")]
        public Guid WorldId { get; set; }
        [XmlElement("Article")]
        public Guid ArticleId { get; set; }

        [JsonIgnore]
        public virtual World World { get; set; }
        [JsonIgnore]
        public virtual Article Article { get; set; }
    }
}