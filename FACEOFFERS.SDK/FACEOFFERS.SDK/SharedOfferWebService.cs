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
    public class SharedOfferWebService : ISharedOfferService
    {
        public async Task<SharedOffer> FindAsync(Guid id)
        {
            try
            {
                var content = await HttpHelper.Request(Constants.FACEOFFERS_AUTH_TOKEN, Constants.FACEOFFERS_API_URL, "api/SharedOffers/ById/" + id, null, HttpRequestType.GET);
                return await content.ReadAsAsync<SharedOffer>();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<IEnumerable<SharedOffer>> GetAsync(Guid offerId)
        {
            HttpContent content = await HttpHelper.Request(Constants.FACEOFFERS_AUTH_TOKEN, Constants.FACEOFFERS_API_URL, "api/SharedOffers/ByOfferId/" + offerId, null, HttpRequestType.GET);
            var jsonString = await content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<SharedOffer>>(jsonString);
        }

        public async Task<IEnumerable<SharedOffer>> GetSharedOffersBySender(Guid consumerId)
        {
            HttpContent content = await HttpHelper.Request(Constants.FACEOFFERS_AUTH_TOKEN, Constants.FACEOFFERS_API_URL, "api/SharedOffers/BySender/" + consumerId, null, HttpRequestType.GET);
            var jsonString = await content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<SharedOffer>>(jsonString);
        }

        public async Task<IEnumerable<SharedOffer>> GetRedeemedOffersAsync(Guid offerId)
        {
            HttpContent content = await HttpHelper.Request(Constants.FACEOFFERS_AUTH_TOKEN, Constants.FACEOFFERS_API_URL, "api/SharedOffers/Redeemed/" + offerId, null, HttpRequestType.GET);
            var jsonString = await content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<SharedOffer>>(jsonString);
        }

        public async Task<IEnumerable<ConsumerSharedOfferSummary>> GetConsumerSharedOffersSummaryAsync(Guid consumerId)
        {
            HttpContent content = await HttpHelper.Request(Constants.FACEOFFERS_AUTH_TOKEN, Constants.FACEOFFERS_API_URL, "api/SharedOffers/ByConsumer/" + consumerId, null, HttpRequestType.GET);
            var jsonString = await content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<ConsumerSharedOfferSummary>>(jsonString);
        }

        public async Task<SharedOffer> InsertAsync(SharedOffer sharedOffer)
        {
            try
            {
                var content = await HttpHelper.Request(Constants.FACEOFFERS_AUTH_TOKEN, Constants.FACEOFFERS_API_URL, "api/Share", sharedOffer, HttpRequestType.POST);
                return await content.ReadAsAsync<SharedOffer>();
            }
            catch (Exception e)
            {
                throw;
            }
        }
        
        public async Task<SharedOffer> InsertByTimeZoneAsync(SharedOffer sharedOffer)
        {
            try
            {
                var content = await HttpHelper.Request(Constants.FACEOFFERS_AUTH_TOKEN, Constants.FACEOFFERS_API_URL, "api/Share/ByTimeZone", sharedOffer, HttpRequestType.POST);
                return await content.ReadAsAsync<SharedOffer>();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<SharedOffer> UpdateAsync(SharedOffer sharedOffer)
        {
            try
            {
                var content = await HttpHelper.Request(Constants.FACEOFFERS_AUTH_TOKEN, Constants.FACEOFFERS_API_URL, "api/SharedOffers", sharedOffer, HttpRequestType.PUT);
                return await content.ReadAsAsync<SharedOffer>();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task DeleteAsync(SharedOffer sharedOffer)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(Guid id)
        {
            try
            {
                var content = await HttpHelper.Request(Constants.FACEOFFERS_AUTH_TOKEN, Constants.FACEOFFERS_API_URL, "api/SharedOffers/" + id, null, HttpRequestType.DELETE);
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
