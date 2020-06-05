using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using DAL.Entities;

namespace BLL.DTO
{
    public class SensorDataDTO
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }
        [JsonPropertyName("sensorId")]
        public Guid SensorId { get; set; }
        [JsonPropertyName("data")]
        public string Data { get; set; }
    }
}