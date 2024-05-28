using Domain.Interfaces;
using Domain.Models;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
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

        public void AddActor(ActorModel model)
        {
            model.Id = Guid.NewGuid().ToString();
           _actorRepository.Add(model); 
        }

        public void DeleteActor(string actorId)
        {
            var actorToDelete = _actorRepository.GetActor(actorId);
            if (actorToDelete == null)
            {
                throw new InvalidDataException("Actor Not Found.");
            }
            _actorRepository.Delete(actorToDelete);

        }

        public ActorModel GetActorDetails(string actorId)
        {
            var actor = _actorRepository.GetActor(actorId);
            if(actor == null)
            {
                throw new InvalidDataException("Actor Not Found.");
            }
            return actor;
        }

        public IEnumerable<BaseActorModel> GetActors(string provider, int? rankStart = null, int? rankEnd = null, int skip = 0, int take = 10)
        {
            var actors = _actorRepository.GetActors(provider, rankStart, rankEnd, skip, take);
            var res = actors.Select(a => new BaseActorModel { Id = a.Id, Name = a.Name }).ToList();
            return res;
        }


        public void UpdateActor(ActorModel model)
        {
            var actor = _actorRepository.GetActor(model.Id);
            if (actor == null)
            {
                throw new InvalidDataException("Actor Not Found.");
            }
            _actorRepository.Update(model);
        }
    }
}
