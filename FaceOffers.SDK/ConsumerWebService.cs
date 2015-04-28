using FaceOffers.Entities;
using FaceOffers.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace FaceOffers.SDK
{
    public class ConsumerWebService : IConsumerService
    {
        public async Task<Consumer> FindAsync(Guid id)
        {
            try
            {
                var content = await HttpHelper.Request(Constants.FACEOFFERS_AUTH_TOKEN, Constants.FACEOFFERS_API_URL, "api/Consumers/ById/" + id, null, HttpRequestType.GET);
                return await content.ReadAsAsync<Consumer>();
            }
            catch(Exception e)
            {
                throw;
            }
        }

        public async Task<Consumer> InsertAsync(Consumer consumer)
        {
            try
            {
                var content = await HttpHelper.Request(Constants.FACEOFFERS_AUTH_TOKEN, Constants.FACEOFFERS_API_URL, "api/Consumers", consumer, HttpRequestType.POST);
                return await content.ReadAsAsync<Consumer>();
            }
            catch(Exception e)
            {
                throw;
            }
        }

        public async Task<Consumer> UpdateAsync(Consumer consumer)
        {
            try
            {
                var content = await HttpHelper.Request(Constants.FACEOFFERS_AUTH_TOKEN, Constants.FACEOFFERS_API_URL, "api/Consumers", consumer, HttpRequestType.PUT);
                return await content.ReadAsAsync<Consumer>();
            }
            catch(Exception e)
            {
                throw;
            }
        }

        public async Task DeleteAsync(Consumer consumer)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(Guid id)
        {
            try
            {
                var content = await HttpHelper.Request(Constants.FACEOFFERS_AUTH_TOKEN, Constants.FACEOFFERS_API_URL, "api/Consumers/" + id, null, HttpRequestType.DELETE);
            }
            catch(Exception e)
            {
                throw;
            }
        }
    }
}
