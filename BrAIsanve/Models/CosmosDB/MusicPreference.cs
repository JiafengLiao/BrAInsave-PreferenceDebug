using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrAInsave.Models.CosmosDB
{
    public class MusicPreference
    {
        [JsonProperty(PropertyName = "Music type")]
        public string MusicType { get; set; }

        [JsonProperty(PropertyName = "Songs")]
        public string Songs { get; set; }

        [JsonProperty(PropertyName = "ID")]
        public string id { get; set; }
    }
}
