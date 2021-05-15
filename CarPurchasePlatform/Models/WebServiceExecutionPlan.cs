using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPurchasePlatform.Models
{
    public class WebServiceExecutionPlan
    {
        public WebServiceExecutionPlan()
        {
            Steps = new List<WebServiceExecutionPlanStep>();
        }

        public List<WebServiceExecutionPlanStep> Steps { get; set; }
        public double Score => Steps != null ? GetQoSScore() : 0.0;

        /// <summary>
        /// Gets accumulated score of all services in the current plan
        /// </summary>
        /// <returns>QoS score of the web services</returns>
        private double GetQoSScore()
        {
            var score = 0.0;

            foreach(var step in Steps)
                foreach (var service in step.Services)
                    score += service.GetQoSScore();

            return Math.Round(score, 2);
        }
    }

    public class WebServiceExecutionPlanStep
    {
        public WebServiceExecutionPlanStep()
        {
            Services = new List<WebService>();
        }
        public List<WebService> Services { get; set; }
        public int Step { get; set; }
    }
}
