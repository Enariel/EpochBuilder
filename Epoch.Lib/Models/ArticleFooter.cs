// Copyright (c) FuchsFarbe Blazor 2024
// Oliver Conover
// FuchsFarbe Studios
namespace Epoch.Lib.Models
{
    [Serializable]
    public class ArticleFooter
    {
        public string Footnotes { get; set; }
        public string AuthorsNotes { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime? ModifiedOn { get; set; }
    }
}