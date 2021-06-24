using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities
{
    public class User : IdentityUser
    {
        //public int Id { get; set; }

        [JsonPropertyName("firstName")]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        [JsonPropertyName("lastName")]
        public string LastName { get; set; }

        [MaxLength(50)]
        [JsonPropertyName("email")]
        public override string Email { get => base.Email; set => base.Email = value; }
        
        [JsonIgnore]
        public virtual ICollection<Questionnaire> Questionnaires { get; set; }
        
        [JsonIgnore]
        public virtual ICollection<Result> Results { get; set; }
    }
}
