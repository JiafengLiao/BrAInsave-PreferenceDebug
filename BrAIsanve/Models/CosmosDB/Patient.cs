using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MvcControlsToolkit.Core.DataAnnotations;
using Newtonsoft.Json;
using BrAInsave.Models.CosmosDB;

namespace BrainsaveDev.Models.CosmosDB
{
    public class Patient
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Owner { get; set; }

        [JsonProperty(PropertyName = "FoodPreference_List"),
             CollectionKey("Id")]
        public IEnumerable<FoodPreference> FoodPreferences { get; set; }

        [JsonProperty(PropertyName = "MusicPreference_List"), 
            CollectionKey("Id")]
        public IEnumerable<MusicPreference> MusicPreferences { get; set; }

        [JsonProperty(PropertyName = "assignedTo")]
        public Person AssignedTo { get; set; }

        [JsonProperty(PropertyName = "team"),
            CollectionKey("Id")]
        public IEnumerable<Person> Team { get; set; }

        [JsonProperty(PropertyName = "isComplete")]
        public bool Completed { get; set; }
    }
}
