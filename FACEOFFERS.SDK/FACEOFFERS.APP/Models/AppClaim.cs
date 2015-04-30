using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACEOFFERS.APP.Models
{
    public class AppClaim
    {
        public System.Guid Id { get; set; }
        public System.DateTime Expires { get; set; }
        public string Token { get; set; }
        public bool Revoked { get; set; }
        public Guid AppId { get; set; }
    }
}
