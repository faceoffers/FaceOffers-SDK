using FaceOffers.Entities;
using FaceOffers.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace FACEOFFERS.SDK
{
    public class AppWebService : IAppService
    {
        public async Task<App> FindAsync(Guid id)
        {
            try
            {
                var content = await HttpHelper.Request(Constants.FACEOFFERS_AUTH_TOKEN, Constants.FACEOFFERS_API_URL, "api/Apps/ById/" + id, null, HttpRequestType.GET);
                return await content.ReadAsAsync<App>();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<IEnumerable<App>> GetAsync(Guid merchantId)
        {
            HttpContent content = await HttpHelper.Request(Constants.FACEOFFERS_AUTH_TOKEN, Constants.FACEOFFERS_API_URL, "api/Apps/" + merchantId, null, HttpRequestType.GET);
            var jsonString = await content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<App>>(jsonString);
        }

        public async Task<App> InsertAsync(App app)
        {
            try
            {
                var content = await HttpHelper.Request(Constants.FACEOFFERS_AUTH_TOKEN, Constants.FACEOFFERS_API_URL, "api/Apps", app, HttpRequestType.POST);
                return await content.ReadAsAsync<App>();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<App> UpdateAsync(App app)
        {
            try
            {
                var content = await HttpHelper.Request(Constants.FACEOFFERS_AUTH_TOKEN, Constants.FACEOFFERS_API_URL, "api/Apps", app, HttpRequestType.PUT);
                return await content.ReadAsAsync<App>();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task DeleteAsync(App app)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(Guid id)
        {
            try
            {
                var content = await HttpHelper.Request(Constants.FACEOFFERS_AUTH_TOKEN, Constants.FACEOFFERS_API_URL, "api/Apps/" + id, null, HttpRequestType.DELETE);
            }
            catch (Exception e)
            {
                throw;
            }
        }


        public Task<AppClaim> InsertClaimAsync(AppClaim claim)
        {
            throw new NotImplementedException();
        }

        public Task<AppClaim> UpdateClaimAsync(AppClaim claim)
        {
            throw new NotImplementedException();
        }
    }
}
