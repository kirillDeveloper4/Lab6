using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using DAL.Entities;

namespace BLL.DTO
{
    public class SensorDTO
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }
        [JsonPropertyName("region")]
        public LocalPoint LocalPoint { get; set; }
        [JsonPropertyName("data")]
        public ICollection<SensorDataDTO> SensorData { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("type")]
        public string Type { get; set; }
        [JsonPropertyName("creationDate")]
        public long CreationDate { get; set; }
    }
}