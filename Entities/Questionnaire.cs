using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities
{
    public class Questionnaire
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [MaxLength(100)]
        [JsonPropertyName("title")]

        public string Title { get; set; }

        [Required]
        [JsonPropertyName("defaultTimer")]
        public int DefaultTimer { get; set; } // En secondes


        [JsonPropertyName("userId")]
        public string UserId { get; set; }
        [JsonIgnore]
        public virtual User User { get; set; }
        public virtual ICollection<Question> Questions { get; set; }


    }
}
