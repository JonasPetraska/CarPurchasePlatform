using CarPurchasePlatform.Extensions;
using CarPurchasePlatform.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CarPurchasePlatform.Services
{
    public class DefaultPlanExecutionerService : IPlanExecutionerService
    {
        private readonly IWebServiceSchemaService _schemaService;

        public DefaultPlanExecutionerService(IWebServiceSchemaService schemaService)
        {
            _schemaService = schemaService;
        }

        public async Task<WebServiceExecutionResult> ExecuteAsync(WebServiceExecutionPlanInstance plan)
        {
            //Get schemas
            var schemasResult = await _schemaService.GetAsync();
            if (schemasResult.ResponseType != ErrorTypeEnum.Success)
                return null;

            var schemas = schemasResult.Content;

            var parameters = plan.Parameters;
            var results = new Dictionary<WebServiceTypeEnum, List<KeyValuePair<string, string>>>();
            var result = new WebServiceExecutionResult();
            result.Results = new List<WebServiceExecutionResultByService>();

            //Execute steps in parallel
            foreach (var step in plan.Steps.OrderBy(x => x.Step).ToList())
            {
                var tasks = step.Services.Select(x => Task.Run(async () =>
                {
                    var schema = schemas.First(y => y.WebServiceType == x.Type);

                    using(var httpClient = new HttpClient())
                    {
                        var queryString = new QueryString();
                        foreach(var input in schema.Inputs)
                            queryString = queryString.Add(input.Name, parameters.First(x => x.Key == input.Name).Value);

                        var message = new HttpRequestMessage(HttpMethod.Get, $"{x.Url}{queryString.ToUriComponent()}");
                        var res = await httpClient.SendAsync(message);
                        if (!res.IsSuccessStatusCode)
                            return;

                        var response = await res.Content.ReadAsStringAsync();
                        if (String.IsNullOrEmpty(response))
                            return;

                        var jObject = JObject.Parse(response);
                        if (jObject == null)
                            return;

                        var children = jObject.Children<JProperty>();

                        var outputs = schema.Outputs.Where(x => children.Any(y => y.Name.ToLower() == x.Name.ToLower())).Select(x => new KeyValuePair<string, string>(x.Name, children.First(y => y.Name.ToLower() == x.Name.ToLower()).Value.ToString())).ToList();
                        var additionalOutputs = jObject.Children<JProperty>().Where(x => !schema.Outputs.Any(y => y.Name.ToLower() == x.Name.ToLower())).Select(x => new KeyValuePair<string, string>(x.Name, x.Value.ToString())).ToList();

                        foreach(var output in outputs)
                        {
                            if (!parameters.ContainsKey(output.Key))
                                parameters.Add(output);

                            if (!result.Results.Any(x => x.Type == schema.WebServiceType))
                                result.Results.Add(new WebServiceExecutionResultByService() { Type = schema.WebServiceType, Objects = new List<WebServiceExecutionResultObject>() });

                            result.Results.FirstOrDefault(x => x.Type == schema.WebServiceType).Objects.Add(new WebServiceExecutionResultObject() { Name = output.Key, Value = output.Value });
                        }

                        if (!result.Results.Any(x => x.Type == schema.WebServiceType))
                            result.Results.Add(new WebServiceExecutionResultByService() { Type = schema.WebServiceType, Objects = new List<WebServiceExecutionResultObject>() });
                        foreach (var output in additionalOutputs)
                            result.Results.FirstOrDefault(x => x.Type == schema.WebServiceType).Objects.Add(new WebServiceExecutionResultObject() { Name = output.Key, Value = output.Value });
                    }
                })).ToList();

                await Task.WhenAll(tasks);
            }

            return result;
        }
    }
}
