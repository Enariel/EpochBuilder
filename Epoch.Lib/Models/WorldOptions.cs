// Copyright (c) FuchsFarbe Blazor 2024
// Oliver Conover
// FuchsFarbe Studios
using System.Xml.Serialization;

namespace Epoch.Lib.Models
{
    public class WorldOptions
    {
        public Guid WorldId { get; set; }
        public string SubTitle { get; set; }
        public string CreditsOverride { get; set; }
        public bool DisplayTableOfContents { get; set; } = true;
        public bool DisplayUncategorizedArticles { get; set; } = true;
        public bool DisplayRecentArticles { get; set; } = true;
    }
}