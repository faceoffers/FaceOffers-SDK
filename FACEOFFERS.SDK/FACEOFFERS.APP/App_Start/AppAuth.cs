using FACEOFFERS.APP.Models;
using FACEOFFERS.SDK;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace FACEOFFERS.APP.App_Start
{
    public class AppAuth
    {
        public static async void AuthenticateAppAsync(string key)
        {
            string endpoint = "api/Apps/Authenticate";
            var data = new AppCredential();
            data.ApiKey = key;

            var client = new HttpClient();
            client.BaseAddress = new Uri(Constants.FACEOFFERS_API_URL);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var param = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            HttpContent contentPost = new StringContent(param, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(endpoint, contentPost);

            var result = response.Content;
            var jsonString = result.ReadAsStringAsync().Result;
            var claim = JsonConvert.DeserializeObject<AppClaim>(jsonString);
            Constants.FACEOFFERS_AUTH_TOKEN = claim.Token.ToString();
        }
    }
}
