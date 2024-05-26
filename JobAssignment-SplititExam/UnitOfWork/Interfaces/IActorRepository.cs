using DataAccess.Entities;
using Domain.Models;
using Repositories.Interfaces;

namespace Repositories.Interfaces
{
    public interface IActorRepository : IRepository<ActorEntity>
    {
        ActorModel GetActor(string actorId);
        IEnumerable<ActorEntity> GetActors(string provider, int? rankStart = null, int? rankEnd = null, int skip = 0, int take = 10);
    }
}
