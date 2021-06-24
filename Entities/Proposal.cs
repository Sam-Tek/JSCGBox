using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Entities
{
    public class Proposal
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [MaxLength(50)]
        [JsonPropertyName("entitled")]
        public string Entitled { get; set; }

        [JsonPropertyName("isCorrect")]
        public bool IsCorrect { get; set; }

        [JsonPropertyName("selected")]
        [NotMapped]
        public bool Selected { get; set; }

        [JsonPropertyName("questionId")]
        [Required]
        public int QuestionId { get; set; }
        
        [JsonIgnore]
        public virtual Question Question { get; set; }

        [JsonIgnore]
        public virtual ICollection<Result> Results { get; set; }

    }
}
