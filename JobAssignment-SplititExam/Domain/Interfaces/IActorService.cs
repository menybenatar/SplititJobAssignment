using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IActorService
    {
        IEnumerable<BaseActorModel> GetActorsSummary(string provider, int? rankStart = null, int? rankEnd = null, int skip = 0, int take = 10);
        ActorModel GetActorDetails(string actorId);
        ActorModel UpdateActor(string actorId, ActorModel request);
        void DeleteActor(string actorId);
        //ActorResponse AddActor(ActorRequest request);

    }
}
