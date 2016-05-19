using System;
using Many.ThirdParty.Core.Commands;
using Many.ThirdParty.Core.Models.ReadingModels;
using Windows.Data.Json;

namespace Many.ThirdParty.Core.Models.AddlModels
{
    public class SearchReadingModel 
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Type { get; set; }

        public string Number { get; set; }
    }
}
