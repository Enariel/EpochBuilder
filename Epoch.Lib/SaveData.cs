// Copyright (c) FuchsFarbe Blazor 2024
// Oliver Conover
// FuchsFarbe Studios
using Epoch.Lib.Models;
using System.Xml.Serialization;

namespace Epoch.Lib
{
    [Serializable]
    [XmlRoot("SessionData")]
    public class SaveData
    {
        [XmlElement("Worlds")]
        public List<World> Worlds { get; set; } = new List<World>();
    }
}