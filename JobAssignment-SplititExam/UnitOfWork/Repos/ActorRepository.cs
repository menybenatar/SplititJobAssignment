using DataAccess;
using DataAccess.Entities;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;
using Repositories.Mappers;

namespace Repositories.Repos
{
    public class ActorRepository : IActorRepository
    {
        private readonly DBContext _dbContext;

        public ActorRepository(DBContext context)
        {
            _dbContext = context;
        }
        public void Add(ActorModel actor)
        {
            var actorEntity = actor.MapToEntity();
            _dbContext.Actors.Add(actorEntity);
            SaveChanges();
        }

        public void Delete(ActorModel actor)
        {
            var actorToDelete = _dbContext.Actors.FirstOrDefault(x=>x.Id== actor.Id);
            if (actorToDelete == null)
            {
                throw new InvalidOperationException();
            }
            _dbContext.Actors.Remove(actorToDelete);
            SaveChanges();
        }

        public void Update(ActorModel model)
        {
            // Retrieve the existing entity from the database
            var actorEntity = _dbContext.Actors.FirstOrDefault(a => a.Id == model.Id);

            if (actorEntity != null)
            {
                // Update properties from the model to the entity
                actorEntity.Name = model.Name;
                actorEntity.Details = model.Details;
                actorEntity.Type = model.Type;
                actorEntity.Rank = model.Rank;
                actorEntity.Source = model.Source;

                // Mark the entity as modified
                _dbContext.Entry(actorEntity).State = EntityState.Modified;

                // Save changes
                SaveChanges();
            }
            else
            {
                // Handle the case where the actor does not exist in the database
                throw new InvalidOperationException("Actor not found.");
            }
        }

        public ActorModel GetActor(string actorId)
        {
            var entity = _dbContext.Actors.FirstOrDefault(x => x.Id == actorId);
            return entity?.MapToModel();
        }

        public void AddActors(IEnumerable<ActorModel> actors)
        {
            var actorsEntities = actors.Select(x => x.MapToEntity()).ToList();
            _dbContext.Actors.AddRange(actorsEntities);
            SaveChanges();
        }
        private void SaveChanges()
        {
             _dbContext.SaveChanges();
        }

        IEnumerable<ActorModel> IActorRepository.GetActors(string provider, int? rankStart, int? rankEnd, int skip, int take)
        {
            var query = _dbContext.Actors.AsQueryable();

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

            return query.Select(x => x.MapToModel()).ToList();
        }
    }
}
