using System;
using System.Collections.Generic;

namespace Entities
{
    public class Proposal
    {
        public int Id { get; set; }
        public string Entitled { get; set; }
        public bool IsCorrect { get; set; }
        public int QuestionId { get; set; }
        public virtual Question Question { get; set; }
        public virtual ICollection<Result> Results { get; set; }

    }
}
