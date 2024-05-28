using Domain.Models;
using Microsoft.Extensions.Options;
using Services.Settings;

namespace Services.Scrapers
{
    public class IMDbScraper : ScraperBase
    {
        private readonly IMDbSettings _settings;

        public IMDbScraper(IOptions<ScraperSettings> options) : base("IMDb", options.Value.IMDb.BaseUrl)
        {
            _settings = options.Value.IMDb;
        }

        public override List<ActorModel> ScrapeActors()
        {
            var nodes = _document.DocumentNode.SelectNodes(_settings.ListXPath);
            List<ActorModel> actors = new List<ActorModel>();

            if (nodes != null)
            {
                foreach (var node in nodes)
                {
                    var type = node.SelectSingleNode(_settings.TypeXPath).FirstChild.InnerText.Trim();
                    var nameAndRank = node.SelectSingleNode(_settings.NameRankXPath).InnerText.Trim().Split(". ");
                    var name = nameAndRank[1];
                    bool rankIsExist = int.TryParse(nameAndRank[0], out int rank);
                    var details = node.SelectSingleNode(_settings.DetailsXPath).InnerText.Trim();

                    var actor = new ActorModel
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = name,
                        Rank = rankIsExist ? rank : 0,
                        Details = details,
                        Source = _provider,
                        Type = type
                    };
                    actors.Add(actor);
                }
            }

            return actors;
        }
    }
}
