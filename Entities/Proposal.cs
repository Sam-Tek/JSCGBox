using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Proposal
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string Entitled { get; set; }

        public bool IsCorrect { get; set; }

        public int QuestionId { get; set; }
        [Required]
        public virtual Question Question { get; set; }

    }
}
