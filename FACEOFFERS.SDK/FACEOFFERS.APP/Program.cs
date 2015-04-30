using FaceOffers.Entities;
using FACEOFFERS.APP.App_Start;
using FACEOFFERS.SDK;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACEOFFERS.APP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("** PRESS ENTER TO AUTHORIZE THIS APP **");
            Console.ReadKey();

            // app validation
            string apiKey = ConfigurationManager.AppSettings["api-key"];
            if (!string.IsNullOrEmpty(apiKey))
                AppAuth.AuthenticateAppAsync(apiKey);

            Console.WriteLine("*** AUTHORIZED ***");
            Console.ReadKey();

            #region Getting list of Plans/Services

            Console.WriteLine("Getting List of Plans");

            IEnumerable<Plan> plans = null;
            plans = GetPlansList().Result;

            #endregion

            Console.ReadKey();

            #region CreateOffer Sample

            Console.WriteLine("Creating an Offer");

            Offer offer = new Offer();
            //offer.MerchantId = *merchantId*; // substitute with Merchant's Id
            //offer.AppId = *appId*; // substitute with App's Id
            //offer.Type = OfferType.PercentageOff;
            //offer.Reward = "10"; // offer amount

            // set this property if OfferType is BOGO
            // merchant.IsRewardBased = true;

            offer.Name = "5% Off anything in Opero Store.";
            //offer.Description = *description*;
            //offer.TermsConditions = *termsAndConditions*;
            //offer.Tags = *tags*;
            //offer.StartDate = *startDate*;
            //offer.EndDate = *endDate*;
            //offer.ExpiryDate = *expiryDate*;
            //offer.Limited = true; // set true if redemption is limited
            //offer.RedemptionLimit = 10;
            //offer.Share = false;
            //offer.OfferImage = *offerImage*;

            // save
            var result = SaveOffer(offer).Result;

            #endregion

            Console.ReadKey();
            Console.Clear();
        }

        private static async Task<IEnumerable<Plan>> GetPlansList()
        {
            PlanWebService _planService = new PlanWebService();
            return await _planService.GetAsync();
        }

        private static async Task<Offer> SaveOffer(Offer model)
        {
            try
            {
                OfferWebService _offerService = new OfferWebService();
                Offer offer = new Offer();

                if (model.Id != Guid.Empty)
                {
                    offer = await _offerService.UpdateAsync(model);
                }
                else
                {
                    offer = await _offerService.InsertAsync(model);
                }

                return offer;
            }
            catch (Exception e)
            {
                // reserved for future use
                Console.WriteLine(e.StackTrace);
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}
