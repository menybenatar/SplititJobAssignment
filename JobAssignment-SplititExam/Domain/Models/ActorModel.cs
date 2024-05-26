using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class ActorModel : BaseActorModel
    {
        public string Details { get; set; }
        public string Type { get; set; }
        public int Rank { get; set; }
        public string Source { get; set; }
    }
}
