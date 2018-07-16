using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrAInsave.DTOs
{
    public class PatientDTO
    {
        public string Id { get; set; } 
        public string Name { get; set; }

        public string Description { get; set; }

        public string Owner { get; set; }

        public IEnumerable<FoodPrefDTO> FoodPreferences { get; set; }

        public IEnumerable<MusicPrefDTO> MusicPreferences { get; set; }

        public string AssignedToEmail { get; set; }

        public string AssignedToId { get; set; }
    }

    public class FoodPrefDTO
    {
        public string Id { get; set; }
        public string FoodType { get; set; }
        public string FoodPreferenceDetail { get; set; }
    }

    public class MusicPrefDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
