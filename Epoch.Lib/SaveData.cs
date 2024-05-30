// Copyright (c) FuchsFarbe Blazor 2024
// Oliver Conover
// FuchsFarbe Studios
using Epoch.Lib.Models;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace Epoch.Lib
{
    [Serializable]
    public class SaveData
    {
        public Profile Profile { get; set; } = new Profile();
        public List<World> Worlds { get; set; } = new List<World>();
        public List<Tag> Tags { get; set; } = new List<Tag>();
        [JsonIgnore]
        public World ActiveWorld => Worlds.FirstOrDefault(x => x.IsActive);
    }

}