using System;
using System.Collections.Generic;

namespace Entities
{
    public class Question
    {
        public int Id { get; set; }
        public string Entitled { get; set; }
        public int Timer { get; set; }
        //public int QuestionnaireId { get; set; }
        public virtual Questionnaire Questionnaire { get; set; }
        public virtual ICollection<Proposal> Proposals { get; set; }

    }
}
