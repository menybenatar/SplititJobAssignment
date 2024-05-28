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
        IEnumerable<BaseActorModel> GetActors(string provider, int? rankStart = null, int? rankEnd = null, int skip = 0, int take = 10);
        ActorModel GetActorDetails(string actorId);
        void UpdateActor(ActorModel model);
        void DeleteActor(string actorId);
        void AddActor(ActorModel model);

    }
}
