using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Result
    {
        public int Id { get; set; }
        public double? Note { get; set; }
        public DateTime ResponseDate { get; set; }

        public string UserId { get; set; }
        public virtual User User { get; set; }

        public virtual ICollection<Proposal> Proposals { get; set; }
    }
}
