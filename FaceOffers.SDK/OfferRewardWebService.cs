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
    public class OfferRewardWebService : IOfferRewardService
    {
        public async Task<OfferReward> FindAsync(Guid id)
        {
            try
            {
                var content = await HttpHelper.Request(Constants.FACEOFFERS_AUTH_TOKEN, Constants.FACEOFFERS_API_URL, "api/OfferRewards/ById/" + id, null, HttpRequestType.GET);
                return await content.ReadAsAsync<OfferReward>();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<OfferReward> FindByOfferIdAsync(Guid id)
        {
            try
            {
                var content = await HttpHelper.Request(Constants.FACEOFFERS_AUTH_TOKEN, Constants.FACEOFFERS_API_URL, "api/OfferRewards/ByOfferId/" + id, null, HttpRequestType.GET);
                return await content.ReadAsAsync<OfferReward>();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<OfferReward> InsertAsync(OfferReward offerReward)
        {
            try
            {
                var content = await HttpHelper.Request(Constants.FACEOFFERS_AUTH_TOKEN, Constants.FACEOFFERS_API_URL, "api/OfferRewards", offerReward, HttpRequestType.POST);
                return await content.ReadAsAsync<OfferReward>();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<OfferReward> UpdateAsync(OfferReward offerReward)
        {
            try
            {
                var content = await HttpHelper.Request(Constants.FACEOFFERS_AUTH_TOKEN, Constants.FACEOFFERS_API_URL, "api/OfferRewards", offerReward, HttpRequestType.PUT);
                return await content.ReadAsAsync<OfferReward>();
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
