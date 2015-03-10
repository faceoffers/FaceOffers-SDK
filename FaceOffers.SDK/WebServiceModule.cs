using FaceOffers.Infrastructure.Services;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceOffers.SDK
{
    public class WebServiceModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IBarcodeService>().To<BarcodeWebService>().InSingletonScope();
            this.Bind<IConsumerService>().To<ConsumerWebService>().InSingletonScope();
            //this.Bind<IMerchantService>().To<MerchantWebService>().InSingletonScope();
            this.Bind<IMerchantConsumerService>().To<MerchantConsumerWebService>().InSingletonScope();
            this.Bind<IMerchantDeveloperService>().To<MerchantDeveloperWebService>().InSingletonScope();
            this.Bind<IMerchantLocationService>().To<MerchantLocationWebService>().InSingletonScope();
            this.Bind<IAppService>().To<AppWebService>().InSingletonScope();
            this.Bind<IOfferService>().To<OfferWebService>().InSingletonScope();
            this.Bind<IOfferLocationService>().To<OfferLocationWebService>().InSingletonScope();
            this.Bind<IOfferShareDiscountService>().To<OfferShareDiscountWebService>().InSingletonScope();
            this.Bind<ISharedOfferService>().To<SharedOfferWebService>().InSingletonScope();
            this.Bind<IUniqueOfferService>().To<UniqueOfferWebService>().InSingletonScope();
            this.Bind<IUserService>().To<UserWebService>().InSingletonScope();
            this.Bind<IPlanService>().To<PlanWebService>().InSingletonScope();
        }

    }
}
