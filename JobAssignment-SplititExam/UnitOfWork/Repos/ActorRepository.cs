using DataAccess;
using DataAccess.Entities;
using Domain.Models;
using Repositories.Interfaces;

namespace Repositories.Repos
{
    public class ActorRepository :IActorRepository
    {
        private readonly DBContext _actorContext;

        public ActorRepository(DBContext context)
        {
            _actorContext = context;
        }
        public async Task AddAsync(ActorEntity actor)
        {
            await _actorContext.Actors.AddAsync(actor);
            await SaveAsync();
        }

        public async void Delete(ActorEntity actor)
        {
            _actorContext.Remove(actor);
            await SaveAsync();
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

        private async Task SaveAsync()
        {
           await _actorContext.SaveChangesAsync();
        }

        public ActorModel GetActor(string actorId)
        {
            throw new NotImplementedException();
        }

        IEnumerable<ActorModel> IActorRepository.GetActors(string provider, int? rankStart, int? rankEnd, int skip, int take)
        {
            throw new NotImplementedException();
        }

        public void AddActors(IEnumerable<ActorModel> actors)
        {
            throw new NotImplementedException();
        }
    }
}
