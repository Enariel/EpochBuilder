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
        public World()
        {
            WorldArticles = new HashSet<WorldArticle>();
            WorldTags = new HashSet<WorldTag>();
        }

        public Guid WorldId { get; set; } = Guid.NewGuid();
        public string Title { get; set; }
        public string Description { get; set; }
        public string Excerpt { get; set; }
        public bool IsActive { get; set; } = false;
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public virtual WorldOptions Options { get; set; }
        public virtual WorldHome Home { get; set; }
        public virtual WorldTime Time { get; set; }
        public virtual ICollection<WorldArticle> WorldArticles { get; set; }
        public virtual ICollection<WorldTag> WorldTags { get; set; }
    }

}