using DataAccess;
using DataAccess.Entities;
using Repositories.Interfaces;

namespace Repositories.Repos
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
        public IEnumerable<ActorEntity> GetActors(string provider, int? rankStart = null, int? rankEnd = null, int skip = 0, int take = 10)
        {
            var query = _actorContext.Actors.AsQueryable();

            if (!string.IsNullOrEmpty(provider))
            {
                query = query.Where(a => a.Source == provider);
            }

            if (rankStart.HasValue)
            {
                query = query.Where(a => a.Rank >= rankStart.Value);
            }

            if (rankEnd.HasValue)
            {
                query = query.Where(a => a.Rank <= rankEnd.Value);
            }

            query = query.Skip(skip).Take(take);

            return query.ToList();
        }

        private void Save()
        {
            _actorContext.SaveChanges();
        }
    }
}
