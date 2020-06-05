using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using DAL.Entities;

namespace BLL.DTO
{
    public class LocalPointDTO
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }
        [JsonPropertyName("calls")]
        public ICollection<CallDTO> Calls { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
}