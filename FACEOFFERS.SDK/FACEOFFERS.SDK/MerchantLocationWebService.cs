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
    public class MerchantLocationWebService : IMerchantLocationService
    {
        public async Task<MerchantLocation> FindAsync(Guid id)
        {
            try
            {
                var content = await HttpHelper.Request(Constants.FACEOFFERS_AUTH_TOKEN, Constants.FACEOFFERS_API_URL, "api/MerchantLocations/ById/" + id, null, HttpRequestType.GET);
                return await content.ReadAsAsync<MerchantLocation>();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<IEnumerable<MerchantLocation>> GetAsync(Guid merchantId)
        {
            HttpContent content = await HttpHelper.Request(Constants.FACEOFFERS_AUTH_TOKEN, Constants.FACEOFFERS_API_URL, "api/MerchantLocations/" + merchantId, null, HttpRequestType.GET);
            var jsonString = await content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<MerchantLocation>>(jsonString);
        }

        public async Task<MerchantLocation> InsertAsync(MerchantLocation merchantLocation)
        {
            try
            {
                var content = await HttpHelper.Request(Constants.FACEOFFERS_AUTH_TOKEN, Constants.FACEOFFERS_API_URL, "api/MerchantLocations", merchantLocation, HttpRequestType.POST);
                return await content.ReadAsAsync<MerchantLocation>();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<MerchantLocation> UpdateAsync(MerchantLocation merchantLocation)
        {
            try
            {
                var content = await HttpHelper.Request(Constants.FACEOFFERS_AUTH_TOKEN, Constants.FACEOFFERS_API_URL, "api/MerchantLocations", merchantLocation, HttpRequestType.PUT);
                return await content.ReadAsAsync<MerchantLocation>();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task DeleteAsync(MerchantLocation merchantLocation)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(Guid id)
        {
            try
            {
                var content = await HttpHelper.Request(Constants.FACEOFFERS_AUTH_TOKEN, Constants.FACEOFFERS_API_URL, "api/MerchantLocations/" + id, null, HttpRequestType.DELETE);
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
