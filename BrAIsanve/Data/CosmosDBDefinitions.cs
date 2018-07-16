using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BrAInsave.Models.CosmosDB;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using MvcControlsToolkit.Business.DocumentDB;

namespace BrAInsave.Data
{
    public static class CosmosDBDefinitions
    {
        private static string accountURI = "https://localhost:8081";
        private static string accountKey = "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";
        public static string DatabaseId { get; private set; } = "PreferenceList";
        public static string PreferenceID { get; private set; } = "Preference";

        public static IDocumentDBConnection GetConnection()
        {
            return new DefaultDocumentDBConnection(accountURI, accountKey, DatabaseId);
        }

        public static async Task Initialize()
        {
            var connection = GetConnection();

            await connection.Client
                .CreateDatabaseIfNotExistsAsync(
                    new Database { Id = DatabaseId });

            DocumentCollection myCollection = new DocumentCollection();
            myCollection.Id = PreferenceID;
            myCollection.IndexingPolicy = new IndexingPolicy(new RangeIndex(DataType.String) { Precision = -1 });
            myCollection.IndexingPolicy.IndexingMode = IndexingMode.Consistent;
            var res=await connection.Client.CreateDocumentCollectionIfNotExistsAsync(
                UriFactory.CreateDatabaseUri(DatabaseId),
                myCollection);
            if (res.StatusCode== System.Net.HttpStatusCode.Created)
                await InitData(connection);
        }
        private static async Task InitData(IDocumentDBConnection connection)
        {
            List<Patient> fakePatients = new List<Patient>();
            for (int i = 0; i < 6; i++)
            {
                var curr = new Patient();
                fakePatients.Add(curr);
                curr.Name = "Patient" + i;
                curr.Description = "Description" + i;
                curr.Completed = i % 2 == 0;
                curr.Id = Guid.NewGuid().ToString();
                curr.Owner = "frank@fake.com";
                if (i >= 0)
                    curr.AssignedTo = new Person
                    {
                        Name = "Francesco",
                        Email = "frank@fake.com",
                        Id = Guid.NewGuid().ToString()
                    };

                var foodPrefList = new List<FoodPreference>();
                for (var j = 0; j < 2; j++)
                {
                    foodPrefList.Add(new FoodPreference
                    {
                        FoodType = "Meal" + i + "_" + j,
                        FoodPreferencesDetail = "Food" + i + "_" + j,
                        Id = Guid.NewGuid().ToString()
                    });
                }
                curr.FoodPreferences = foodPrefList;

                var musicPrefList = new List<MusicPreference>();
                for (var j = 0; j < 2; j++)
                {
                    musicPrefList.Add(new MusicPreference
                    {
                        MusicType = "Rock",
                        Songs = "It is my life",
                        Id = Guid.NewGuid().ToString()
                    });
                }
                curr.MusicPreferences = musicPrefList;
            }
            foreach (var patient in fakePatients)
            {
                await connection.Client
                    .CreateDocumentAsync(
                    UriFactory
                        .CreateDocumentCollectionUri(
                            DatabaseId, PreferenceID), 
                    patient);
                
            }
        }
    }
}
