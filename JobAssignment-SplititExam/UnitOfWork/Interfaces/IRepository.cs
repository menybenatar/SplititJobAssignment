﻿using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IRepository<TEntity>
    {
        void Add(TEntity actor);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        
    }
}
