using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Question
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Entitled { get; set; }

        public int Timer { get; set; } // En secondes

        [Required]
        public int QuestionnaireId { get; set; }
        [Required]
        public virtual Questionnaire Questionnaire { get; set; }
        public virtual ICollection<Proposal> Proposals { get; set; }

    }
}
