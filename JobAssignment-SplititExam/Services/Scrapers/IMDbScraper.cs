using DataAccess.Entities;
using Domain.Models;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Services.Scrapers
{
    public class IMDbScraper : ScraperBase
    {
        public IMDbScraper() : base("IMDb", "https://www.imdb.com/list/ls054840033/")
        {
        }
        public override List<ActorModel> ScrapeActors()
        {
            //Select the nodes containing actor information
            // This XPath targets the list items that include actor details
            var nodes = _document.DocumentNode.SelectNodes("//li[contains(@class, 'ipc-metadata-list-summary-item')]");
            List<ActorModel> actors = new List<ActorModel>();
            if (nodes != null)
            {
                foreach (var node in nodes)
                {
                    var type = node.SelectSingleNode(".//ul[contains(@class, 'ipc-inline-list')]").FirstChild.InnerText.Trim();
                    var nameAndRamk = node.SelectSingleNode(".//h3[contains(@class, 'ipc-title__text')]").InnerText.Trim().Split(". ");
                    var name = nameAndRamk[1];
                    bool rankIsExsit = int.TryParse(nameAndRamk[0], out int rank);
                    var details = node.SelectSingleNode(".//div[contains(@class, 'ipc-html-content-inner-div')]").InnerText.Trim();
                    var actor = new ActorModel
                    {
                        Name = name,
                        Rank = rankIsExsit ? rank : 0,
                        Details = details,
                        Source = _provider,
                        Type = type,

                    };
                    actors.Add(actor);

                }
            }
            
            return actors;
        }

    }

}
