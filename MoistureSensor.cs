using System;
using BonsaiTrees;

namespace MoistureSensors
{
    public class MoistureSensor
    {
        public Guid Id { get; set; }
        public BonsaiTree? relatedTree { get; set; }
        public string? summary { get; set; }
    }
}
