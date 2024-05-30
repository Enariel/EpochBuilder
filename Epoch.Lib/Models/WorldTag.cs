// Copyright (c) FuchsFarbe Blazor 2024
// Oliver Conover
// FuchsFarbe Studios
namespace Epoch.Lib.Models
{
    [Serializable]
    public class WorldTag
    {
        public long TagId { get; set; }
        public Guid WorldId { get; set; }
        public virtual Tag Tag { get; set; }
        public virtual World World { get; set; }
    }
}