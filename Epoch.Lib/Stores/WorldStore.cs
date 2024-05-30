// Copyright (c) FuchsFarbe Blazor 2024
// Oliver Conover
// FuchsFarbe Studios
using Epoch.Lib.Models;

namespace Epoch.Lib
{
    [Serializable]
    public record WorldStore
    {
        public List<World> Worlds { get; set; } = new List<World>();
    }
}