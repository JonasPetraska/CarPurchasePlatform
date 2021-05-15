using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPurchasePlatform.Models
{
    public class WebServiceExecutionPlanInstance : WebServiceExecutionPlan
    {
        public IDictionary<string, string> Parameters { get; set; }
    }
}
