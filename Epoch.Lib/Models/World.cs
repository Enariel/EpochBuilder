// Copyright (c) FuchsFarbe Blazor 2024
// Oliver Conover
// FuchsFarbe Studios
namespace Epoch.Lib.Models
{
    /// <summary>
    /// Represents a constructed world.
    /// </summary>
    public class World
    {
        public Guid WorldId { get; set; }
        public string? WorldName { get; set; }
        public string? Description { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}