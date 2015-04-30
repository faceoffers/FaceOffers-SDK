using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACEOFFERS.SDK.ViewModels
{
    public class MerchantViewModel
    {
        public Guid Id { get; set; }
        public Guid? PlanId { get; set; }
        public string CompanyName { get; set; }
        public string UserId { get; set; }
        public bool Active { get; set; }
    }
}
