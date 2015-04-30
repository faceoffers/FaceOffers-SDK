using FaceOffers.Entities;
using FaceOffers.Infrastructure.Services;
using FACEOFFERS.SDK.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace FACEOFFERS.SDK
{
    public class MerchantWebService : IMerchantService
    {
        public async Task<Merchant> FindAsync(Guid id)
        {
            try
            {
                var content = await HttpHelper.Request(Constants.FACEOFFERS_AUTH_TOKEN, Constants.FACEOFFERS_API_URL, "api/Merchants/ById/" + id, null, HttpRequestType.GET);
                return await content.ReadAsAsync<Merchant>();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Merchant>> GetMerchantsWithPlanAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Merchant> GetByUserIdAsync(string userId)
        {
            try
            {
                var content = await HttpHelper.Request(Constants.FACEOFFERS_AUTH_TOKEN, Constants.FACEOFFERS_API_URL, "api/Merchants/ByUserId/" + userId, null, HttpRequestType.GET);
                var result = await content.ReadAsAsync<MerchantViewModel>();

                return new Merchant()
                {
                    Id = result.Id,
                    UserId = result.UserId,
                    CompanyName = result.CompanyName,
                    Active = result.Active
                };
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<Merchant> InsertAsync(Merchant merchant)
        {
            try
            {
                var content = await HttpHelper.Request(Constants.FACEOFFERS_AUTH_TOKEN, Constants.FACEOFFERS_API_URL, "api/Merchants", merchant, HttpRequestType.POST);
                return await content.ReadAsAsync<Merchant>();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<Merchant> UpdateAsync(Merchant merchant)
        {
            try
            {
                var content = await HttpHelper.Request(Constants.FACEOFFERS_AUTH_TOKEN, Constants.FACEOFFERS_API_URL, "api/Merchants", merchant, HttpRequestType.PUT);
                return await content.ReadAsAsync<Merchant>();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task DeleteAsync(Merchant merchant)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(Guid id)
        {
            try
            {
                var content = await HttpHelper.Request(Constants.FACEOFFERS_AUTH_TOKEN, Constants.FACEOFFERS_API_URL, "api/Merchants/" + id, null, HttpRequestType.DELETE);
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
