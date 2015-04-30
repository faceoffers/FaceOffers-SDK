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
    public class OfferShareDiscountWebService : IOfferShareDiscountService
    {
        public async Task<OfferShareDiscount> FindAsync(Guid id)
        {
            try
            {
                var content = await HttpHelper.Request(Constants.FACEOFFERS_AUTH_TOKEN, Constants.FACEOFFERS_API_URL, "api/OfferShareDiscounts/ById/" + id, null, HttpRequestType.GET);
                return await content.ReadAsAsync<OfferShareDiscount>();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<IEnumerable<OfferShareDiscount>> GetAsync(Guid offerId)
        {
            HttpContent content = await HttpHelper.Request(Constants.FACEOFFERS_AUTH_TOKEN, Constants.FACEOFFERS_API_URL, "api/OfferShareDiscounts/ByOfferId/" + offerId, null, HttpRequestType.GET);
            var jsonString = await content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<OfferShareDiscount>>(jsonString);
        }

        public async Task<OfferShareDiscount> InsertAsync(OfferShareDiscount offerShareDiscount)
        {
            try
            {
                var content = await HttpHelper.Request(Constants.FACEOFFERS_AUTH_TOKEN, Constants.FACEOFFERS_API_URL, "api/OfferShareDiscounts", offerShareDiscount, HttpRequestType.POST);
                return await content.ReadAsAsync<OfferShareDiscount>();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<OfferShareDiscount> UpdateAsync(OfferShareDiscount offerShareDiscount)
        {
            try
            {
                var content = await HttpHelper.Request(Constants.FACEOFFERS_AUTH_TOKEN, Constants.FACEOFFERS_API_URL, "api/OfferShareDiscounts", offerShareDiscount, HttpRequestType.PUT);
                return await content.ReadAsAsync<OfferShareDiscount>();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task DeleteAsync(OfferShareDiscount offerShareDiscount)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(Guid id)
        {
            try
            {
                var content = await HttpHelper.Request(Constants.FACEOFFERS_AUTH_TOKEN, Constants.FACEOFFERS_API_URL, "api/OfferShareDiscounts/" + id, null, HttpRequestType.DELETE);
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
