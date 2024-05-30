// Copyright (c) FuchsFarbe Blazor 2024
// Oliver Conover
// FuchsFarbe Studios
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

        public virtual World World { get; set; }
        public virtual Article Article { get; set; }
    }
}