using System;
using System.Collections.Generic;

namespace Entities
{
    public class Questionnaire
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Result> Results { get; set; }
        public virtual ICollection<Question> Questions { get; set; }


    }
}
