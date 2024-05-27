using Domain.Interfaces;
using Domain.Models;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ActorService : IActorService
    {
        private readonly IActorRepository _actorRepository;

        public ActorService(IActorRepository actorRepository)
        {
            _actorRepository = actorRepository;
        }

        public void DeleteActor(string actorId)
        {
            throw new NotImplementedException();
        }

        public ActorModel GetActorDetails(string actorId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BaseActorModel> GetActorsSummary(string provider, int? rankStart = null, int? rankEnd = null, int skip = 0, int take = 10)
        {
            var actors = _actorRepository.GetActors(provider, rankStart, rankEnd, skip, take);
            var res = actors.Select(a => new BaseActorModel { Id = a.Id, Name = a.Name }).ToList();
            return res;
        }

        public ActorModel UpdateActor(string actorId, ActorModel request)
        {
            throw new NotImplementedException();
        }
    }
}
