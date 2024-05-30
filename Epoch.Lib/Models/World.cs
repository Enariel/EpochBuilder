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

        [XmlAttribute("Id", typeof(Guid))]
        public Guid WorldId { get; set; } = Guid.NewGuid();
        [XmlElement("Name")]
        public string WorldName { get; set; }
        [XmlElement("Description")]
        public string Description { get; set; }
        public string Excerpt { get; set; }
        public bool IsActive { get; set; } = false;
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual ICollection<WorldArticle> WorldArticles { get; set; }
        public virtual ICollection<WorldTag> WorldTags { get; set; }
    }

}