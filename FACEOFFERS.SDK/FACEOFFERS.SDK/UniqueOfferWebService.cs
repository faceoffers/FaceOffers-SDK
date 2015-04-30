using FaceOffers.Entities;
using FaceOffers.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using FaceOffers.Entities.DataModels;

namespace FACEOFFERS.SDK
{
    public class UniqueOfferWebService : IUniqueOfferService
    {
        public async Task<UniqueOffer> FindAsync(Guid id)
        {
            //try
            //{
            //    var content = await HttpHelper.Request(Constants.FACEOFFERS_AUTH_TOKEN, Constants.FACEOFFERS_API_URL, "api/UniqueOffers/ById/" + id, null, HttpRequestType.GET);
            //    return await content.ReadAsAsync<UniqueOffer>();
            //}
            //catch (Exception e)
            //{
            //    throw;
            //}
            throw new NotImplementedException();
        }

        public async Task<UniqueOffer> FindByOfferIdAsync(Guid offerId)
        {
            try
            {
                var content = await HttpHelper.Request(Constants.FACEOFFERS_AUTH_TOKEN, Constants.FACEOFFERS_API_URL, "api/UniqueOffers/ByOfferId/" + offerId, null, HttpRequestType.GET);
                return await content.ReadAsAsync<UniqueOffer>();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<UniqueOffer> FindByConsumerAsync(Guid consumerId)
        {
            try
            {
                var content = await HttpHelper.Request(Constants.FACEOFFERS_AUTH_TOKEN, Constants.FACEOFFERS_API_URL, "api/UniqueOffers/ByConsumer/" + consumerId, null, HttpRequestType.GET);
                return await content.ReadAsAsync<UniqueOffer>();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<UniqueOffer> FindByOfferAndConsumerAsync(Guid offerId, Guid? consumerId)
        {
            try
            {
                var content = await HttpHelper.Request(Constants.FACEOFFERS_AUTH_TOKEN, Constants.FACEOFFERS_API_URL, "api/UniqueOffers/ByOfferConsumerIds/" + offerId + '/' + consumerId.Value, null, HttpRequestType.GET);
                return await content.ReadAsAsync<UniqueOffer>();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<IEnumerable<UniqueOffer>> GetUniqueOffersbyOfferIdAsync(Guid offerId)
        {
            HttpContent content = await HttpHelper.Request(Constants.FACEOFFERS_AUTH_TOKEN, Constants.FACEOFFERS_API_URL, "api/UniqueOffers/ByOfferId/" + offerId, null, HttpRequestType.GET);
            var jsonString = await content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<UniqueOffer>>(jsonString);
        }

        public async Task<IEnumerable<ConsumerOffersSummary>> GetConsumerOffersSummaryAsync(Guid consumerId)
        {
            HttpContent content = await HttpHelper.Request(Constants.FACEOFFERS_AUTH_TOKEN, Constants.FACEOFFERS_API_URL, "api/UniqueOffers/ByConsumerId/" + consumerId, null, HttpRequestType.GET);
            var jsonString = await content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<ConsumerOffersSummary>>(jsonString);
        }

        public async Task<UniqueOffer> InsertAsync(UniqueOffer uniqueOffer)
        {
            try
            {
                var content = await HttpHelper.Request(Constants.FACEOFFERS_AUTH_TOKEN, Constants.FACEOFFERS_API_URL, "api/UniqueOffers", uniqueOffer, HttpRequestType.POST);
                return await content.ReadAsAsync<UniqueOffer>();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<UniqueOffer> UpdateAsync(UniqueOffer uniqueOffer)
        {
            try
            {
                var content = await HttpHelper.Request(Constants.FACEOFFERS_AUTH_TOKEN, Constants.FACEOFFERS_API_URL, "api/UniqueOffers", uniqueOffer, HttpRequestType.PUT);
                return await content.ReadAsAsync<UniqueOffer>();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task DeleteAsync(UniqueOffer uniqueOffer)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(Guid id)
        {
            try
            {
                var content = await HttpHelper.Request(Constants.FACEOFFERS_AUTH_TOKEN, Constants.FACEOFFERS_API_URL, "api/UniqueOffers/" + id, null, HttpRequestType.DELETE);
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
