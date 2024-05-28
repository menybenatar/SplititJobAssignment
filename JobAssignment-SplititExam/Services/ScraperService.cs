using Domain.Interfaces;
using Domain.Models;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ScraperService : IScraperService
    {
        private readonly IEnumerable<IScraper> _scrapers;
        private readonly IActorRepository _actorRepository;

        public ScraperService(IEnumerable<IScraper> scrapers, IActorRepository actorRepository)
        {
            _scrapers = scrapers;
            _actorRepository = actorRepository;
        }

        public async Task ScrapeActorsAsync()
        {
            foreach (var scraper in _scrapers)
            {
                var actors = await scraper.ScrapeActorsAsync();
                AddActorsToDatabase(actors);
            }
        }

        private void AddActorsToDatabase(List<ActorModel> actors)
        {
            _actorRepository.AddActors(actors);
        }
    }
}
