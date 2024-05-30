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
        [XmlElement("Id", typeof(Guid))]
        public Guid WorldId { get; set; } = Guid.NewGuid();
        public string WorldName { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
    }
}