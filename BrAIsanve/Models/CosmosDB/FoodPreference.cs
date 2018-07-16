using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrAInsave.Models.CosmosDB
{
    public class FoodPreference
    {
        [JsonProperty(PropertyName = "Food Type")]
        public string FoodType { get; set; }

        [JsonProperty(PropertyName = "Food Preference detail")]
        public string FoodPreferencesDetail { get; set; }

        [JsonProperty(PropertyName = "ID")]
        public string Id { get; set; }
    }
}
