using CarPurchasePlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPurchasePlatform.Services
{
    public interface IPlanExecutionerService
    {
        Task<WebServiceExecutionResult> ExecuteAsync(WebServiceExecutionPlanInstance plan);
    }
}
