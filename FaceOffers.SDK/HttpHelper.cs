using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;


namespace FaceOffers.SDK
{
    public static class HttpHelper
    {
        public static async Task<HttpContent> Request(string token, string baseURL, string endpoint, object data, HttpRequestType type)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("X-API-TOKENAUTH", token);
                client.BaseAddress = new Uri(baseURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    HttpResponseMessage response = null;

                    switch (type)
                    {
                        case HttpRequestType.GET:
                            {
                                response = await client.GetAsync(endpoint);
                                break;
                            }

                        case HttpRequestType.POST:
                            {
                                var param = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                                HttpContent contentPost = new StringContent(param, Encoding.UTF8, "application/json");
                                response = await client.PostAsync(endpoint, contentPost);
                                break;
                            }

                        case HttpRequestType.PUT:
                            {
                                var param = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                                HttpContent contentPost = new StringContent(param, Encoding.UTF8, "application/json");
                                response = await client.PutAsync(endpoint, contentPost);
                                break;
                            }

                        case HttpRequestType.DELETE:
                            {
                                response = await client.DeleteAsync(endpoint);
                                break;
                            }


                        default:
                            throw new Exception("Unsupported Request Type");
                    }


                    response.EnsureSuccessStatusCode();    // Throw if not a success code.
                    return response.Content;
                    // TODO: Perform more operations on the response to parse the HttpContent with generics
                    // Ideally we can abstract away the 
                    //Product product = await response.Content.ReadAsAsync>Product>();
                }
                catch (HttpRequestException ex)
                {
                    // Handle exception.
                    throw ex;
                }
            }
        }
    }

    public enum HttpRequestType
    {
        GET,
        POST,
        PUT,
        DELETE,
        HEAD
    }
}
