using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Settings
{
    public class IMDbSettings
    {
        public string BaseUrl { get; set; }
        public string ListXPath { get; set; }
        public string TypeXPath { get; set; }
        public string NameRankXPath { get; set; }
        public string DetailsXPath { get; set; }
    }
}
