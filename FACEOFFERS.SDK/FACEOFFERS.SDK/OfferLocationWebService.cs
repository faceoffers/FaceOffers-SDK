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
    public class OfferLocationWebService : IOfferLocationService
    {
        public async Task<OfferLocation> FindAsync(Guid id)
        {
            try
            {
                var content = await HttpHelper.Request(Constants.FACEOFFERS_AUTH_TOKEN, Constants.FACEOFFERS_API_URL, "api/OfferLocations/ById/" + id, null, HttpRequestType.GET);
                return await content.ReadAsAsync<OfferLocation>();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<IEnumerable<OfferLocation>> GetByOfferIdAsync(Guid offerId)
        {
            var content = await HttpHelper.Request(Constants.FACEOFFERS_AUTH_TOKEN, Constants.FACEOFFERS_API_URL, "api/OfferLocations/ByOfferId/" + offerId, null, HttpRequestType.GET);
            return await content.ReadAsAsync<IEnumerable<OfferLocation>>();
        }

        public async Task<IEnumerable<OfferLocation>> GetByMerchantLocationIdAsync(Guid merchantLocationId)
        {
            try
            {
                var content = await HttpHelper.Request(Constants.FACEOFFERS_AUTH_TOKEN, Constants.FACEOFFERS_API_URL, "api/OfferLocations/ByMerchantLocationId/" + merchantLocationId, null, HttpRequestType.GET);
                return await content.ReadAsAsync<IEnumerable<OfferLocation>>();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<OfferLocation> InsertAsync(OfferLocation offerLocation)
        {
            try
            {
                var content = await HttpHelper.Request(Constants.FACEOFFERS_AUTH_TOKEN, Constants.FACEOFFERS_API_URL, "api/OfferLocations", offerLocation, HttpRequestType.POST);
                return await content.ReadAsAsync<OfferLocation>();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task DeleteAsync(OfferLocation offerLocation)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(Guid id)
        {
            try
            {
                var content = await HttpHelper.Request(Constants.FACEOFFERS_AUTH_TOKEN, Constants.FACEOFFERS_API_URL, "api/OfferLocations/" + id, null, HttpRequestType.DELETE);
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
