using Domain.Interfaces;
using Domain.Models;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Services.Scrapers
{
    public abstract class ScraperBase : IScraper
    {
        protected HtmlDocument _document;
        protected string _provider;
        protected string _url;
        protected HtmlWeb _web;

        public ScraperBase(string provider, string url)
        {
            _web = new HtmlWeb();
            _url = url;
            _provider = provider;
        }

        protected async Task LoadDocumentAsync()
        {
            _document = await _web.LoadFromWebAsync(_url);
        }
        public abstract List<ActorModel> ScrapeActors();

        public async Task<List<ActorModel>> ScrapeActorsAsync()
        {
            await LoadDocumentAsync();
            return ScrapeActors();
        }
    }
}
