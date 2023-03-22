using System;

namespace Models.MoistureSensors
{
    public class MoistureSensor
    {
        public Guid Id { get; set; }
        public Guid? relatedTreeId { get; set; }
        public string? summary { get; set; }
    }
}
