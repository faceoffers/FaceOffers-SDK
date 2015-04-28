using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

using FaceOffers.Entities;
using FaceOffers.Infrastructure.Services;

namespace FaceOffers.SDK
{
    public class PlanWebService : IPlanService
    {
        public async Task<Plan> FindAsync(Guid id)
        {
            try
            {
                var content = await HttpHelper.Request(Constants.FACEOFFERS_AUTH_TOKEN, Constants.FACEOFFERS_API_URL, "api/Plans/ById/" + id, null, HttpRequestType.GET);
                return await content.ReadAsAsync<Plan>();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Plan>> GetAsync()
        {
            HttpContent content = await HttpHelper.Request(Constants.FACEOFFERS_AUTH_TOKEN, Constants.FACEOFFERS_API_URL, "api/Plans", null, HttpRequestType.GET);
            var jsonString = await content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<Plan>>(jsonString);
        }

        public async Task<IEnumerable<Plan>> GetUpgradablePlansAsync(int level)
        {
            HttpContent content = await HttpHelper.Request(Constants.FACEOFFERS_AUTH_TOKEN, Constants.FACEOFFERS_API_URL, "api/Plans/UpgradablePlans/" + level, null, HttpRequestType.GET);
            var jsonString = await content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<Plan>>(jsonString);
        }

        public async Task<IEnumerable<Plan>> GetDowngradablePlansAsync(int level)
        {
            HttpContent content = await HttpHelper.Request(Constants.FACEOFFERS_AUTH_TOKEN, Constants.FACEOFFERS_API_URL, "api/Plans/DowngradablePlans/" + level, null, HttpRequestType.GET);
            var jsonString = await content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<Plan>>(jsonString);
        }
    }
}
