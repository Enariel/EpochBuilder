// Copyright (c) FuchsFarbe Blazor 2024
// Oliver Conover
// FuchsFarbe Studios
namespace Epoch.Lib.Models
{
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