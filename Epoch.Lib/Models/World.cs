// Copyright (c) FuchsFarbe Blazor 2024
// Oliver Conover
// FuchsFarbe Studios
using System.Xml.Serialization;

namespace Epoch.Lib.Models
{
    /// <summary>
    /// Represents a constructed world.
    /// </summary>
    [Serializable]
    public class World
    {
        public Guid WorldId { get; set; } = Guid.NewGuid();
        public string Title { get; set; }
        public string Description { get; set; }
        public string Excerpt { get; set; }
        public bool IsActive { get; set; } = false;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime? ModifiedOn { get; set; }
        public WorldOptions Options { get; set; } = new WorldOptions();
        public WorldHome Home { get; set; } = new WorldHome();
        public WorldTime Time { get; set; } = new WorldTime();
        public List<WorldArticle> WorldArticles { get; set; } = new List<WorldArticle>();
        public List<WorldTag> WorldTags { get; set; } = new List<WorldTag>();
    }

}