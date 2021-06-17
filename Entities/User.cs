using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class User
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

        [MaxLength(50)]
        public string Email { get; set; }

        public virtual ICollection<Questionnaire> Questionnaires { get; set; }
        public virtual ICollection<Result> Results { get; set; }
    }
}
