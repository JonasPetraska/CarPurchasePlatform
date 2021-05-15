using CarPurchasePlatform.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CarPurchasePlatform.Repositories
{
    public class JsonWebServiceRepository : IWebServiceRepository
    {
        public static string PathToFile { get; set; } = "wwwroot/data/web-services.json";
        public static string PathToQoSParametersFile { get; set; } = "wwwroot/data/web-service-qos-parameters.json";

        public async Task<Response> DeleteAsync(WebService webService)
        {
            var getResult = await GetAsync();
            if (getResult.ResponseType != ErrorTypeEnum.Success)
                return new Response(true);

            var allEntities = getResult.Content.ToList();
            if (allEntities == null || !allEntities.Any())
                return new Response(false);

            var entity = allEntities.FirstOrDefault(x => x.Id == webService.Id);
            if (entity == null)
                return new Response(false);

            allEntities.Remove(entity);
            File.WriteAllText(PathToFile, JsonConvert.SerializeObject(allEntities));

            //Remove QoS parameters as well
            if (File.Exists(PathToQoSParametersFile))
            {
                var qosParameters = JsonConvert.DeserializeObject<IEnumerable<WebServiceQoSParameter>>(File.ReadAllText(PathToQoSParametersFile)).ToList();
                qosParameters.RemoveAll(x => x.WebServiceId == webService.Id);
                File.WriteAllText(PathToQoSParametersFile, JsonConvert.SerializeObject(qosParameters));
            }

            return new Response(true);
        }

        public Task<Response<IEnumerable<WebService>>> GetAsync()
        {
            if (File.Exists(PathToFile))
            {
                var webServices = JsonConvert.DeserializeObject<IEnumerable<WebService>>(File.ReadAllText(PathToFile));
                if (File.Exists(PathToQoSParametersFile))
                {
                    var qosParameters = JsonConvert.DeserializeObject<IEnumerable<WebServiceQoSParameter>>(File.ReadAllText(PathToQoSParametersFile));
                    if (qosParameters.Any())
                        foreach (var webService in webServices)
                            webService.QoSParameters = new ObservableCollection<WebServiceQoSParameter>(qosParameters.Where(x => x.WebServiceId == webService.Id).ToList());
                }

                return Task.FromResult(new Response<IEnumerable<WebService>>(webServices.OrderBy(x => x.Id).ToList()));
            }
            else
                return Task.FromResult(new Response<IEnumerable<WebService>>(new List<WebService>()));
        }

        public Task<Response<IEnumerable<WebServiceQoS>>> GetQoSParametersAsync()
        {
            var list = new List<WebServiceQoS>();

            list.Add(new WebServiceQoS() { WebServiceType = WebServiceTypeEnum.AutomobileSearch, Name = "RankiniuBuduTvirtinamiSkelbimai", Type = typeof(bool), Importance = 10 });
            list.Add(new WebServiceQoS() { WebServiceType = WebServiceTypeEnum.AutomobileSearch, Name = "AudituojamaAuditoriu", Type = typeof(bool), Importance = 8 });
            list.Add(new WebServiceQoS() { WebServiceType = WebServiceTypeEnum.AutomobileSearch, Name = "SukciavimoApsauga", Type = typeof(bool), Importance = 10 });
            list.Add(new WebServiceQoS() { WebServiceType = WebServiceTypeEnum.AutomobileSearch, Name = "StebimiIrTvirtinamiPardavejai", Type = typeof(bool), Importance = 7 });

            list.Add(new WebServiceQoS() { WebServiceType = WebServiceTypeEnum.AutomobileHistory, Name = "TikrinamuSaliuSkaicius", Type = typeof(int), Importance = 7 });
            list.Add(new WebServiceQoS() { WebServiceType = WebServiceTypeEnum.AutomobileHistory, Name = "BendradarbiaujaSuInstitucijomis", Type = typeof(bool), Importance = 10 });
            list.Add(new WebServiceQoS() { WebServiceType = WebServiceTypeEnum.AutomobileHistory, Name = "SuteikiaGarantija", Type = typeof(bool), Importance = 5 });
            list.Add(new WebServiceQoS() { WebServiceType = WebServiceTypeEnum.AutomobileHistory, Name = "PateikiaSenuSkelbimuNuotraukas", Type = typeof(bool), Importance = 4 });

            list.Add(new WebServiceQoS() { WebServiceType = WebServiceTypeEnum.Insurance, Name = "TeikiaKasko", Type = typeof(bool), Importance = 5 });
            list.Add(new WebServiceQoS() { WebServiceType = WebServiceTypeEnum.Insurance, Name = "RegistruotaLietuvoje", Type = typeof(bool), Importance = 10 });
            list.Add(new WebServiceQoS() { WebServiceType = WebServiceTypeEnum.Insurance, Name = "MetaiRinkoje", Type = typeof(int), Importance = 10 });


            return Task.FromResult(new Response<IEnumerable<WebServiceQoS>>(list));
        }

        public async Task<Response<IEnumerable<WebServiceQoS>>> GetQoSParametersAsync(WebServiceTypeEnum WebServiceType)
        {
            var res = await GetQoSParametersAsync();
            if (res.ResponseType != ErrorTypeEnum.Success)
                return res;

            return new Response<IEnumerable<WebServiceQoS>>(res.Content.Where(x => x.WebServiceType == WebServiceType).ToList());
        }

        public async Task<Response> InsertAsync(WebService webService)
        {
            var getResult = await GetAsync();
            if (getResult.ResponseType != ErrorTypeEnum.Success)
                return new Response(true);

            var allEntities = getResult.Content.ToList();
            if (allEntities.Any(x => x.Id == webService.Id))
                return new Response(false);

            var maxNumber = !allEntities.Any() ? 0 : allEntities.Max(x => x.Id);
            webService.Id = maxNumber + 1;

            allEntities.Add(webService);
            File.WriteAllText(PathToFile, JsonConvert.SerializeObject(allEntities));

            if (webService.QoSParameters != null && webService.QoSParameters.Any())
            {
                var listToWrite = webService.QoSParameters;
                var qosParameters = !File.Exists(PathToQoSParametersFile) ? new List<WebServiceQoSParameter>() : JsonConvert.DeserializeObject<IEnumerable<WebServiceQoSParameter>>(File.ReadAllText(PathToQoSParametersFile));
                //Assign ids
                var maxQoSNumber = !qosParameters.Any() ? 0 : qosParameters.Max(x => x.Id);

                foreach(var parameter in listToWrite)
                {
                    parameter.Id = maxQoSNumber + 1;
                    maxQoSNumber++;
                }

                if (qosParameters.Any())
                    listToWrite = new ObservableCollection<WebServiceQoSParameter>(qosParameters.Union(listToWrite).ToList());

                File.WriteAllText(PathToQoSParametersFile, JsonConvert.SerializeObject(listToWrite));
            }

            return new Response(true);
        }

        public async Task<Response> UpdateAsync(WebService webService)
        {
            var getResult = await GetAsync();
            if (getResult.ResponseType != ErrorTypeEnum.Success)
                return new Response(true);

            var allEntities = getResult.Content.ToList();
            if (allEntities == null || !allEntities.Any())
                return new Response(false);

            var entity = allEntities.FirstOrDefault(x => x.Id == webService.Id);
            if (entity == null)
                return new Response(false);

            allEntities.Remove(entity);
            allEntities.Add(webService);
            File.WriteAllText(PathToFile, JsonConvert.SerializeObject(allEntities));

            if (webService.QoSParameters != null && webService.QoSParameters.Any())
            {
                var listToWrite = webService.QoSParameters;
                var qosParameters = !File.Exists(PathToQoSParametersFile) ? new List<WebServiceQoSParameter>() : JsonConvert.DeserializeObject<List<WebServiceQoSParameter>>(File.ReadAllText(PathToQoSParametersFile));

                var newParameters = listToWrite.Where(x => x.Id == 0).ToList();
                var updateParameters = listToWrite.Where(x => x.Id > 0).ToList();
                var deleteParameters = qosParameters.Where(x => x.WebServiceId == webService.Id && !listToWrite.Any(y => y.Id == x.Id && y.Id != 0)).ToList();

                if (newParameters.Any())
                {
                    //Assign ids
                    var maxQoSNumber = !qosParameters.Any() ? 0 : qosParameters.Max(x => x.Id);

                    foreach (var parameter in newParameters)
                    {
                        parameter.Id = maxQoSNumber + 1;
                        maxQoSNumber++;
                    }

                    qosParameters = qosParameters.Union(newParameters).ToList();
                }

                if (updateParameters.Any())
                {
                    foreach (var parameter in updateParameters)
                    {
                        var qosEntity = qosParameters.FirstOrDefault(x => x.Id == parameter.Id);
                        if (qosEntity == null)
                            return new Response(false);

                        qosParameters.Remove(qosEntity);
                        qosParameters.Add(parameter);
                    }
                }

                if (deleteParameters.Any())
                {
                    foreach (var parameter in deleteParameters)
                    {
                        var qosEntity = qosParameters.FirstOrDefault(x => x.Id == parameter.Id);
                        if (qosEntity == null)
                            return new Response(false);

                        qosParameters.Remove(qosEntity);
                    }
                }

                File.WriteAllText(PathToQoSParametersFile, JsonConvert.SerializeObject(qosParameters));
            }

            return new Response(true);
        }
    }
}
