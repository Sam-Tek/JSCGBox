using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities
{
    public class Question
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [MaxLength(100)]
        [Required]
        [JsonPropertyName("entitled")]
        public string Entitled { get; set; }

        [JsonPropertyName("timer")]
        public int? Timer { get; set; } // En secondes

        [Required]
        [JsonPropertyName("order")]
        public int Order { get; set; }

        [Required]
        [JsonPropertyName("questionnaireId")]
        public int QuestionnaireId { get; set; }
        //[Required] Delete because Required is for only questionnaireId,
        //when I need to create a question ModelState.IsValid block me because Questionnaire is empty
        [JsonIgnore]
        public virtual Questionnaire Questionnaire { get; set; }
        [JsonIgnore]
        public virtual ICollection<Proposal> Proposals { get; set; }

    }
}
