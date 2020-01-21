using System;
using System.Text.Json.Serialization;

namespace questions4me_apirestful_net.Models
{
    public class Question
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("created_by")]
        public string CreatedBy { get; set; }

        [JsonPropertyName("content")]
        public string Content { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }
        
        [JsonPropertyName("answered_at")]
        public DateTime? AnsweredAt { get; set; }
    }
}