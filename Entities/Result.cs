using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities
{
    public class Result
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        
        [JsonPropertyName("note")]
        public double? Note { get; set; }
        
        [JsonPropertyName("responseDate")]
        public DateTime ResponseDate { get; set; }

        [JsonPropertyName("userId")]
        public string UserId { get; set; }
        [JsonIgnore]
        public virtual User User { get; set; }

        [JsonIgnore]
        public virtual ICollection<Proposal> Proposals { get; set; }
    }
}
