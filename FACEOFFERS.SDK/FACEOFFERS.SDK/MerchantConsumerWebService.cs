using FaceOffers.Entities;
using FaceOffers.Entities.DataModels;
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
    public class MerchantConsumerWebService : IMerchantConsumerService
    {
        public async Task<MerchantConsumer> FindAsync(Guid id)
        {
            try
            {
                var content = await HttpHelper.Request(Constants.FACEOFFERS_AUTH_TOKEN, Constants.FACEOFFERS_API_URL, "api/MerchantConsumers/ById/" + id, null, HttpRequestType.GET);
                return await content.ReadAsAsync<MerchantConsumer>();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<ConsumerProfileSummary> GetConsumerSummaryAsync(Guid consumerId)
        {
            try
            {
                var content = await HttpHelper.Request(Constants.FACEOFFERS_AUTH_TOKEN, Constants.FACEOFFERS_API_URL, "api/MerchantConsumers/ByConsumerId/" + consumerId, null, HttpRequestType.GET);
                return await content.ReadAsAsync<ConsumerProfileSummary>();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<IEnumerable<MerchantConsumer>> GetAsync(Guid merchantId)
        {
            HttpContent content = await HttpHelper.Request(Constants.FACEOFFERS_AUTH_TOKEN, Constants.FACEOFFERS_API_URL, "api/MerchantConsumers/" + merchantId, null, HttpRequestType.GET);
            var jsonString = await content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<MerchantConsumer>>(jsonString);
        }

        public async Task<MerchantConsumer> InsertAsync(MerchantConsumer merchantConsumer)
        {
            try
            {
                var content = await HttpHelper.Request(Constants.FACEOFFERS_AUTH_TOKEN, Constants.FACEOFFERS_API_URL, "api/MerchantConsumers", merchantConsumer, HttpRequestType.POST);
                return await content.ReadAsAsync<MerchantConsumer>();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<MerchantConsumer> UpdateAsync(MerchantConsumer merchantConsumer)
        {
            try
            {
                var content = await HttpHelper.Request(Constants.FACEOFFERS_AUTH_TOKEN, Constants.FACEOFFERS_API_URL, "api/MerchantConsumers", merchantConsumer, HttpRequestType.PUT);
                return await content.ReadAsAsync<MerchantConsumer>();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task DeleteAsync(MerchantConsumer merchantConsumer)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(Guid id)
        {
            try
            {
                var content = await HttpHelper.Request(Constants.FACEOFFERS_AUTH_TOKEN, Constants.FACEOFFERS_API_URL, "api/MerchantConsumers/" + id, null, HttpRequestType.DELETE);
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
