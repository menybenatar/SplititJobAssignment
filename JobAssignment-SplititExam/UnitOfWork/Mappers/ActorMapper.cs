using DataAccess.Entities;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Mappers
{
    public static class ActorMapper
    {
        public static ActorEntity MapToEntity(this ActorModel model)
        {
            if (model == null)
                throw new ArgumentNullException("Model can't be null.");
            return new ActorEntity
            {
                Id = model.Id,
                Name = model.Name,
                Details = model.Details,
                Type = model.Type,
                Rank = model.Rank,
                Source = model.Source
            };
        }
        public static ActorModel MapToModel(this ActorEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("Entity can't be null.");
            return new ActorModel
            {
                Id = entity.Id,
                Name = entity.Name,
                Details = entity.Details,
                Type = entity.Type,
                Rank = entity.Rank,
                Source = entity.Source
            };
        }
    }
}
