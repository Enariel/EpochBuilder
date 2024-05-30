// Copyright (c) FuchsFarbe Blazor 2024
// Oliver Conover
// FuchsFarbe Studios
using System.Xml.Serialization;

namespace Epoch.Lib.Models
{
    [Serializable]
    public class WorldTime
    {
        public Guid WorldId { get; set; }
        public string BeforeEraName { get; set; }
        public string BeforeEraAbbreviation { get; set; }
        public string AfterEraName { get; set; }
        public string AfterEraAbbreviation { get; set; }
        public string CurrentDisplay { get; set; }
        public int CurrentYear { get; set; }
        public int CurrentMonth { get; set; }
        public int CurrentDay { get; set; }
    }
}