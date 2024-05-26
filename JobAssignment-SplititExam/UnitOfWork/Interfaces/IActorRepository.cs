using DataAccess.Entities;
using Domain.Models;
using UnitOfWork.Interfaces;

namespace Repositories.Interfaces
{
    public interface IActorRepository : IRepository<ActorEntity>
    {
        ActorModel GetActor(string actorId);
    }
}
