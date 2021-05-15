using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPurchasePlatform.Models
{
    public class WebServiceExecutionResult
    {
        public List<WebServiceExecutionResultByService> Results { get; set; }
    }

    public class WebServiceExecutionResultByService
    {
        public WebServiceTypeEnum Type { get; set; }
        public List<WebServiceExecutionResultObject> Objects { get; set; }
    }

    public class WebServiceExecutionResultObject
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
