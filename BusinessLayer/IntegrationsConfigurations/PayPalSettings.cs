using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Configurations
{
    public  class PayPalSettings
    {
        public string ClientId { get; set; }
        public string Secret { get; set; }
        public string BaseUrl { get; set; }
        public string ReturnUrl { get; set; }
        public string CancelUrl { get; set; }
    }
}
