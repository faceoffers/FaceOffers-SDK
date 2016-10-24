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
    public class BarcodeWebService : IBarcodeService
    {
        public async Task<Barcode> FindAsync(Guid id)
        {
            try
            {
                var content = await HttpHelper.Request(Constants.FACEOFFERS_AUTH_TOKEN, Constants.FACEOFFERS_API_URL, "api/Barcodes/ById/" + id, null, HttpRequestType.GET);
                return await content.ReadAsAsync<Barcode>();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<Barcode> InsertAsync(Guid offerId)
        {
            try
            {   
                var content = await HttpHelper.Request(Constants.FACEOFFERS_AUTH_TOKEN, Constants.FACEOFFERS_API_URL, String.Format("api/Barcodes?offerId={0}", offerId), null, HttpRequestType.POST);
                return await content.ReadAsAsync<Barcode>();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<Barcode> UpdateAsync(Barcode barcode)
        {
            try
            {
                var content = await HttpHelper.Request(Constants.FACEOFFERS_AUTH_TOKEN, Constants.FACEOFFERS_API_URL, "api/Barcodes", barcode, HttpRequestType.PUT);
                return await content.ReadAsAsync<Barcode>();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task DeleteAsync(Barcode barcode)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(Guid id)
        {
            try
            {
                var content = await HttpHelper.Request(Constants.FACEOFFERS_AUTH_TOKEN, Constants.FACEOFFERS_API_URL, "api/Barcodes/" + id, null, HttpRequestType.DELETE);
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
