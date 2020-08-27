using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LifeinsuranceApi.Model
{
    public class ServicebusKeys
    {
        public string ServiceBus { get; set; }
        public string Sender { get; set; }
        public string SRSTopic { get; set; }
        public string EntityType { get; set; }
        public string DestinationSystem { get; set; }

        //ED webservice reference
        public string EdWebserviceURL { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

    }
}
