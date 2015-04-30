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
    public class UserWebService : IUserService
    {
        public async Task<User> FindAsync(string id)
        {
            try
            {
                var content = await HttpHelper.Request(Constants.FACEOFFERS_AUTH_TOKEN, Constants.FACEOFFERS_API_URL, "api/Users/ById/" + id, null, HttpRequestType.GET);
                return await content.ReadAsAsync<User>();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<User> FindByUsernameAsync(string username)
        {
            try
            {
                var content = await HttpHelper.Request(Constants.FACEOFFERS_AUTH_TOKEN, Constants.FACEOFFERS_API_URL, "api/Users/ByUsername/" + username + "/", null, HttpRequestType.GET);
                return await content.ReadAsAsync<User>();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<UserSummary> InsertAsync(User user)
        {
            try
            {
                var content = await HttpHelper.Request(Constants.FACEOFFERS_AUTH_TOKEN, Constants.FACEOFFERS_API_URL, "api/Users", user, HttpRequestType.POST);
                return await content.ReadAsAsync<UserSummary>();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<UserSummary> UpdateAsync(User user)
        {
            try
            {
                var content = await HttpHelper.Request(Constants.FACEOFFERS_AUTH_TOKEN, Constants.FACEOFFERS_API_URL, "api/Users", user, HttpRequestType.PUT);
                return await content.ReadAsAsync<UserSummary>();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task DeleteAsync(User user)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(string id)
        {
            try
            {
                var content = await HttpHelper.Request(Constants.FACEOFFERS_AUTH_TOKEN, Constants.FACEOFFERS_API_URL, "api/Users/" + id, null, HttpRequestType.DELETE);
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
