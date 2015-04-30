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
    public class OfferWebService : IOfferService
    {
        public async Task<Offer> FindAsync(Guid id)
        {
            try
            {
                var content = await HttpHelper.Request(Constants.FACEOFFERS_AUTH_TOKEN, Constants.FACEOFFERS_API_URL, "api/Offers/ById/" + id, null, HttpRequestType.GET);
                return await content.ReadAsAsync<Offer>();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Offer>> GetAsync(Guid merchantId)
        {
            HttpContent content = await HttpHelper.Request(Constants.FACEOFFERS_AUTH_TOKEN, Constants.FACEOFFERS_API_URL, "api/Offers/" + merchantId, null, HttpRequestType.GET);
            var jsonString = await content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<Offer>>(jsonString);
        }

        public async Task<IEnumerable<Offer>> GetActiveOffersAsync(Guid merchantId)
        {
            HttpContent content = await HttpHelper.Request(Constants.FACEOFFERS_AUTH_TOKEN, Constants.FACEOFFERS_API_URL, "api/Offers/Active/" + merchantId, null, HttpRequestType.GET);
            var jsonString = await content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<Offer>>(jsonString);
        }

        public async Task<IEnumerable<Offer>> GetByAppIdAsync(Guid appId)
        {
            HttpContent content = await HttpHelper.Request(Constants.FACEOFFERS_AUTH_TOKEN, Constants.FACEOFFERS_API_URL, "api/Offers/ByAppId/" + appId, null, HttpRequestType.GET);
            var jsonString = await content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<Offer>>(jsonString);
        }

        public async Task<IEnumerable<Offer>> GetByTagsAsync(string tags)
        {
            HttpContent content = await HttpHelper.Request(Constants.FACEOFFERS_AUTH_TOKEN, Constants.FACEOFFERS_API_URL, "api/Offers/ByTags/" + tags, null, HttpRequestType.GET);
            var jsonString = await content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<Offer>>(jsonString);
        }

        public async Task<IEnumerable<OfferSummary>> GetOffersSummaryAsync(Guid merchantId)
        {
            HttpContent content = await HttpHelper.Request(Constants.FACEOFFERS_AUTH_TOKEN, Constants.FACEOFFERS_API_URL, "api/Offers/Summary/" + merchantId, null, HttpRequestType.GET);
            var jsonString = await content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<OfferSummary>>(jsonString);
        }

        public async Task<IEnumerable<OfferSummary>> GetActiveOffersSummaryAsync(Guid merchantId)
        {
            HttpContent content = await HttpHelper.Request(Constants.FACEOFFERS_AUTH_TOKEN, Constants.FACEOFFERS_API_URL, "api/Offers/ActiveSummary/" + merchantId, null, HttpRequestType.GET);
            var jsonString = await content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<OfferSummary>>(jsonString);
        }

        public async Task<IEnumerable<OfferSummary>> GetInactiveOffersSummaryAsync(Guid merchantId)
        {
            HttpContent content = await HttpHelper.Request(Constants.FACEOFFERS_AUTH_TOKEN, Constants.FACEOFFERS_API_URL, "api/Offers/Inactive/" + merchantId, null, HttpRequestType.GET);
            var jsonString = await content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<OfferSummary>>(jsonString);
        }

        public async Task<IEnumerable<OfferSummary>> GetExpiredOffersSummaryAsync(Guid merchantId)
        {
            HttpContent content = await HttpHelper.Request(Constants.FACEOFFERS_AUTH_TOKEN, Constants.FACEOFFERS_API_URL, "api/Offers/Expired/" + merchantId, null, HttpRequestType.GET);
            var jsonString = await content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<OfferSummary>>(jsonString);
        }

        public async Task<Offer> InsertAsync(Offer offer)
        {
            try
            {
                var content = await HttpHelper.Request(Constants.FACEOFFERS_AUTH_TOKEN, Constants.FACEOFFERS_API_URL, "api/Offers", offer, HttpRequestType.POST);
                return await content.ReadAsAsync<Offer>();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<Offer> UpdateAsync(Offer offer)
        {
            try
            {
                var content = await HttpHelper.Request(Constants.FACEOFFERS_AUTH_TOKEN, Constants.FACEOFFERS_API_URL, "api/Offers", offer, HttpRequestType.PUT);
                return await content.ReadAsAsync<Offer>();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task DeleteAsync(Offer offer)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(Guid id)
        {
            try
            {
                var content = await HttpHelper.Request(Constants.FACEOFFERS_AUTH_TOKEN, Constants.FACEOFFERS_API_URL, "api/Offers/" + id, null, HttpRequestType.DELETE);
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
