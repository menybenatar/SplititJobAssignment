using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IScraper
    {
        Task<List<ActorModel>> ScrapeActorsAsync();
    }
}
