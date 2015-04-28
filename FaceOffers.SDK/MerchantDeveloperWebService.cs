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
    public class MerchantDeveloperWebService : IMerchantDeveloperService
    {
        public async Task<MerchantDeveloper> FindAsync(Guid id)
        {
            try
            {
                var content = await HttpHelper.Request(Constants.FACEOFFERS_AUTH_TOKEN, Constants.FACEOFFERS_API_URL, "api/Developers/ById/" + id, null, HttpRequestType.GET);
                return await content.ReadAsAsync<MerchantDeveloper>();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<MerchantDeveloper> FindByUserAsync(string userId)
        {
            try
            {
                var content = await HttpHelper.Request(Constants.FACEOFFERS_AUTH_TOKEN, Constants.FACEOFFERS_API_URL, "api/Developers/ByUserId/" + userId, null, HttpRequestType.GET);
                return await content.ReadAsAsync<MerchantDeveloper>();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<IEnumerable<MerchantDeveloper>> GetAsync(Guid merchantId)
        {
            HttpContent content = await HttpHelper.Request(Constants.FACEOFFERS_AUTH_TOKEN, Constants.FACEOFFERS_API_URL, "api/Developers/" + merchantId, null, HttpRequestType.GET);
            var jsonString = await content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<MerchantDeveloper>>(jsonString);
        }

        public async Task<IEnumerable<MerchantDeveloper>> GetByUserAsync(string userId)
        {
            HttpContent content = await HttpHelper.Request(Constants.FACEOFFERS_AUTH_TOKEN, Constants.FACEOFFERS_API_URL, "api/Developers/AllByUserId/" + userId, null, HttpRequestType.GET);
            var jsonString = await content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<MerchantDeveloper>>(jsonString);
        }

        public async Task<MerchantDeveloper> InsertAsync(MerchantDeveloper merchantDeveloper)
        {
            try
            {
                var content = await HttpHelper.Request(Constants.FACEOFFERS_AUTH_TOKEN, Constants.FACEOFFERS_API_URL, "api/Developers", merchantDeveloper, HttpRequestType.POST);
                var result = await content.ReadAsAsync<MerchantDeveloper>();
                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task DeleteAsync(MerchantDeveloper merchantDeveloper)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(Guid id)
        {
            try
            {
                var content = await HttpHelper.Request(Constants.FACEOFFERS_AUTH_TOKEN, Constants.FACEOFFERS_API_URL, "api/Developers/" + id, null, HttpRequestType.DELETE);
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
