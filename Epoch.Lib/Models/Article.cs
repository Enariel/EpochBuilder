// Copyright (c) FuchsFarbe Blazor 2024
// Oliver Conover
// FuchsFarbe Studios
using System.Xml.Serialization;

namespace Epoch.Lib.Models
{
    [Serializable]
    public class Article
    {
        public Guid ArticleId { get; set; } = Guid.NewGuid();
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Content { get; set; }
        public string Credits { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime? ModifiedOn { get; set; }
        public Preferences Prefs { get; set; } = new Preferences();
        public ArticleFooter Footer { get; set; } = new ArticleFooter();
        public ArticleSideBar SideBar { get; set; } = new ArticleSideBar();
        public List<ArticleSection> Sections { get; set; } = new List<ArticleSection>();
        public List<Tag> Tags { get; set; } = new List<Tag>();
    }

    [Serializable]
    public class ArticleSection
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int Order { get; set; } = 0;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime? ModifiedOn { get; set; }
    }

    [Serializable]
    public class ArticleFooter
    {
        public string Footnotes { get; set; }
        public string AuthorsNotes { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime? ModifiedOn { get; set; }
    }

    [Serializable]
    public class ArticleSideBar
    {
        public string Top { get; set; }
        public string TopContent { get; set; }
        public string Bottom { get; set; }
        public string BottomContent { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime? ModifiedOn { get; set; }
    }
}