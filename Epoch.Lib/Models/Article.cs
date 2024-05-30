// Copyright (c) FuchsFarbe Blazor 2024
// Oliver Conover
// FuchsFarbe Studios
using System.Xml.Serialization;

namespace Epoch.Lib.Models
{
    [Serializable]
    public class Article
    {
        public Article()
        {
            WorldArticles = new HashSet<WorldArticle>();
            ArticleTags = new HashSet<ArticleTag>();
        }

        public Guid ArticleId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string SubTitle { get; set; }
        public string Credits { get; set; }
        // Footer
        public string Footnotes { get; set; }
        public string AuthorsNotes { get; set; }
        // Sidebars
        public string SidebarTop { get; set; }
        public string SidebarTopContent { get; set; }
        public string SidebarBottom { get; set; }
        public string SidebarBottomContent { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }

        // Prefs
        [XmlElement("Preferences", typeof(Preferences))]
        public virtual Preferences Prefs { get; set; } = new Preferences();
        public virtual ICollection<WorldArticle> WorldArticles { get; set; }
        public virtual ICollection<ArticleTag> ArticleTags { get; set; }
    }
}