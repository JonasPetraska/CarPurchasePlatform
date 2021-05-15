using CarPurchasePlatform.Extensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CarPurchasePlatform.Models
{
    public class WebService
    {
        public WebService()
        {
            QoSParameters = new ObservableCollection<WebServiceQoSParameter>();
        }

        [Key]
        public int Id { get; set; }
        public WebServiceTypeEnum Type { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public string Url { get; set; }
        public string PingUrl { get; set; }

        //QoS parameters
        [Range(1, 1000)]
        public int ResponseTime { get; set; }

        [Range(1, 1000)]
        public int Cost { get; set; }

        [Range(0, 10)]
        public int Availability { get; set; }

        [Range(1, 10)]
        public int SuccessRate { get; set; }

        [Range(1, 10)]
        public int Reputation { get; set; }

        //Additional QoS parameters, by partner domain
        [JsonIgnore]
        public ObservableCollection<WebServiceQoSParameter> QoSParameters { get; set; }

        public double GetQoSScore()
        {
            var score = 0.0;
            score += ReduceNumber(10, Availability) * 1;
            score -= ReduceNumber(10, ResponseTime) * 0.9;
            score += SuccessRate * 0.9;
            score -= ReduceNumber(10, Cost) * 0.5;
            score += Reputation * 0.7;

            if (QoSParameters != null && QoSParameters.Any())
            {
                foreach (var parameter in QoSParameters)
                {
                    if (parameter.Value == null)
                        continue;

                    if (parameter.Type == typeof(bool))
                    {
                        var valBool = bool.Parse(parameter.Value);
                        score += parameter.Importance/10 * (valBool ? 10 : 0);
                    }
                    else if (parameter.Type == typeof(int))
                    {
                        var valInt = int.Parse(parameter.Value);
                        score += parameter.Importance/10 * ReduceNumber(10, valInt);
                    }
                    else if (parameter.Type == typeof(double))
                    {
                        var valDouble = double.Parse(parameter.Value);
                        score += parameter.Importance/10 * ReduceNumber(10, valDouble);
                    }
                }
            }

            return Math.Round(score, 2);
        }

        // We assume that number cannot be over 1000
        private double ReduceNumber(int maxNumber, double number, int maxDefaultNumber = 1000)
        {
            var reduced = number <= maxNumber ? number : Math.Abs(number / maxDefaultNumber * maxNumber);
            return reduced;
        }
    }

    public enum WebServiceTypeEnum
    {
        [Display(Name = "Automobilių paieška")]
        AutomobileSearch,

        [Display(Name = "Automobilių istorija")]
        AutomobileHistory,
        
        [Display(Name = "Lizingas")]
        Lease,

        [Display(Name = "Paskola")]
        Loan,

        [Display(Name = "Draudimas")]
        Insurance,

        [Display(Name = "Registracija")]
        Registration
    }

    public class WebServiceQoS
    {
        public string Name { get; set; }

        [JsonIgnore]
        public string NormalizedName => Name.FromCamelCase();

        public Type Type { get; set; }

        [Range(0, 10)]
        public int Importance { get; set; }
        public WebServiceTypeEnum WebServiceType { get; set; }
    }

    public class WebServiceQoSParameter : WebServiceQoS
    {
        [Key]
        public int Id { get; set; }

        public int WebServiceId { get; set; }
        public string Value { get; set; }
    }
}
