// Copyright (c) FuchsFarbe Blazor 2024
// Oliver Conover
// FuchsFarbe Studios
namespace Epoch.Lib.Models
{
    [Serializable]
    public class Preferences
    {
        public bool IsNSFW { get; set; } = false;
        public bool AllowComments { get; set; } = true;
        public bool AllowContentCopy { get; set; } = false;
        public bool DisplayAuthors { get; set; } = false;
        public bool DisplayTitle { get; set; } = false;
        public bool ShowInTableOfContents { get; set; } = false;
    }
}