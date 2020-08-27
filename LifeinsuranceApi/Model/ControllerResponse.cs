using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LifeinsuranceApi.Model
{
    public class ControllerResponse
    {
        public bool Processed { get; set; }

        public string MessageId { get; set; }

        public string Body { get; set; }
    }
}
