using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class User : IdentityUser
    {
        //public int Id { get; set; }

        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

        [MaxLength(50)]
        public override string Email { get => base.Email; set => base.Email = value; }
        public virtual ICollection<Questionnaire> Questionnaires { get; set; }
        public virtual ICollection<Result> Results { get; set; }
    }
}
