using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;
using DAL.Entities;

namespace BLL.DTO
{
    public class CallDTO
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }
        [JsonPropertyName("point_id")]
        public Guid LocalPointId { get; set; }
        [JsonPropertyName("caller_number")]
        public string Number { get; set; }
        [JsonPropertyName("call_decryption")]
        public string CallDecryption { get; set; }
    }
}
