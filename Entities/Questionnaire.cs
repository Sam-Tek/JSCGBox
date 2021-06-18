using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Questionnaire
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        public int DefaultTimer { get; set; } // En secondes


        public string UserId { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Question> Questions { get; set; }


    }
}
