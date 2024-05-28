using DataAccess.Entities;
using Domain.Models;
using Repositories.Interfaces;

namespace Repositories.Interfaces
{
    public interface IActorRepository : IRepository<ActorModel>
    {
        ActorModel GetActor(string actorId);
        IEnumerable<ActorModel> GetActors(string provider, int? rankStart = null, int? rankEnd = null, int skip = 0, int take = 10);
        void AddActors(IEnumerable<ActorModel> actors);
    }
}
