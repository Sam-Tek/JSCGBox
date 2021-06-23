using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Proposal
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string Entitled { get; set; }

        public bool IsCorrect { get; set; }

        [NotMapped]
        public bool Selected { get; set; }

        [Required]
        public int QuestionId { get; set; }
        public virtual Question Question { get; set; }

        public virtual ICollection<Result> Results { get; set; }

    }
}
