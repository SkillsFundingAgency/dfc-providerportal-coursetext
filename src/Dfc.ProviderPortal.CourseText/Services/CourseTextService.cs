using Dfc.ProviderPortal.CourseText.Interfaces;
using Dfc.ProviderPortal.CourseText.Models;
using Dfc.ProviderPortal.CourseText.Settings;
using Dfc.ProviderPortal.Packages;
using Microsoft.Azure.Documents.Client;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dfc.ProviderPortal.CourseText.Services
{
    public class CourseTextService : ICourseTextService
    {
        private readonly ICosmosDbHelper _cosmosDbHelper;
        private readonly ICosmosDbCollectionSettings _settings;

        public CourseTextService(
            ICosmosDbHelper cosmosDbHelper,
            IOptions<CosmosDbCollectionSettings> settings)
        {
            Throw.IfNull(cosmosDbHelper, nameof(cosmosDbHelper));
            Throw.IfNull(settings, nameof(settings));

            _cosmosDbHelper = cosmosDbHelper;
            _settings = settings.Value;
        }
        public async Task<IEnumerable<CourseTextModel>> GetAllCourseText(ILogger log)
        {
            try
            {
                // Get all course documents in the collection
                string token = null;
                Task<FeedResponse<dynamic>> task = null;
                List<dynamic> docs = new List<dynamic>();
                log.LogInformation("Getting all courses from collection");

                // Read documents in batches, using continuation token to make sure we get them all
                using (DocumentClient client = _cosmosDbHelper.GetClient())
                {
                    do
                    {
                        task = client.ReadDocumentFeedAsync(UriFactory.CreateDocumentCollectionUri("providerportal", _settings.CourseTextCollectionId),
                                                            new FeedOptions { MaxItemCount = -1, RequestContinuation = token });
                        token = task.Result.ResponseContinuation;
                        log.LogInformation("Collating results");
                        docs.AddRange(task.Result.ToList());
                    } while (token != null);
                }

                // Cast the returned data by serializing to json and then deserialising into Course objects
                log.LogInformation($"Serializing data for {docs.LongCount()} courses");
                string json = JsonConvert.SerializeObject(docs);
                return JsonConvert.DeserializeObject<IEnumerable<CourseTextModel>>(json);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
