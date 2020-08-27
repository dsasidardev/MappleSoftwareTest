using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LifeinsuranceApi.Model
{
    public class DBConSettingsModel
    {
        public string DbConn { get; set; }
        public string SpForDataExtract { get; set; }
        public string SpForGetPlanId { get; set; }
        public string SpForNetPrice { get; set; }
        public string SpForInsertCustomerData { get; set; }
        public string SpForDeleteCustomerData { get; set; }
        public string SpForGetCustomerData { get; set; }
        public string SpForUpdateCustomerData { get; set; }      

    }

}
