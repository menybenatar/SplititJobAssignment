using DataAccess;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork.Interfaces;

namespace UnitOfWork.Repos
{
    public class ActorRepository : IRepository<ActorEntity>
    {
        private readonly ActorContext _actorContext;

        public ActorRepository(ActorContext context)
        {
            _actorContext = context;
        }
        public void Add(ActorEntity actor)
        {
            _actorContext.Actors.Add(actor);
            Save();
        }

        public void Delete(ActorEntity actor)
        {
            _actorContext.Remove(actor);
            Save();
        }

        public void Update(ActorEntity entity)
        {
            throw new NotImplementedException();
        }
        private void Save()
        {
            _actorContext.SaveChanges();
        }
    }
}
