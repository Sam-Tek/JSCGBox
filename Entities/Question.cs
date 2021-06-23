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

        public int? Timer { get; set; } // En secondes

        public int Order { get; set; }

        [Required]
        public int QuestionnaireId { get; set; }
        //[Required] Delete because Required is for only questionnaireId,
        //when I need to create a question ModelState.IsValid block me because Questionnaire is empty
        public virtual Questionnaire Questionnaire { get; set; }
        public virtual ICollection<Proposal> Proposals { get; set; }

    }
}
