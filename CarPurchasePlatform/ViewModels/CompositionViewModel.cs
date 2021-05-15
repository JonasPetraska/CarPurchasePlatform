using CarPurchasePlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPurchasePlatform.ViewModels
{
    public class CompositionViewModel
    {
        public CompositionViewModel()
        {
            LeasePeriods = new List<int>()
            {
                1, 2, 3, 4, 5, 6, 7
            };

            LeaseInitialDepositPcts = new List<int>()
            {
                10, 15, 20, 25, 30, 35, 40, 45, 50
            };

            LeaseLeftOverPcts = new List<int>()
            {
                0, 5, 10, 15, 20, 25, 30
            };
        }

        public IEnumerable<Manufacturer> Manufacturers { get; set; }
        public IEnumerable<Model> ManufacturerModels { get; set; }
        public IEnumerable<int> ModelYears { get; set; }
        public IEnumerable<int> LeasePeriods { get; set; }
        public IEnumerable<int> LeaseLeftOverPcts { get; set; }
        public IEnumerable<int> LeaseInitialDepositPcts { get; set; }

        //Car
        public string SelectedManufacturerName { get; set; }
        public string SelectedModelName { get; set; }
        public int? SelectedYear { get; set; }

        //Person
        public string PersonalNumber { get; set; }

        //General
        //public double? MaxTotalPrice { get; set; }

        //Loan
        public double? MaxLoanPercentage { get; set; }

        //Lease
        public int? LeaseInitialDepositPct { get; set; }
        public int? LeaseLeftOverPct { get; set; }
        public int? LeasePeriod { get; set; }

        //Loan/lease
        public double MaxMonthlyPay { get; set; }

        //Section activators
        public bool IsInsuranceRequired { get; set; }
        public bool IsCarHistoryRequired { get; set; }
        public bool IsLoanLeaseRequired { get; set; }
        public bool IsRegistrationFeeCalculationRequired { get; set; }
        public int? LoanLeaseSelection { get; set; }
        public bool IsLoanVisible { get; set; }
        public bool IsLeaseVisible { get; set; }
        public bool ShowCompositionPlan { get; set; }
        public bool ShowCompositionPlanInstances { get; set; }
        public bool ShowCompositionExecutionResult { get; set; }

        //Results
        public string CompositionPlan { get; set; }
        public WebServiceExecutionPlan SelectedPlan { get; set; }
        public IEnumerable<WebServiceExecutionPlan> ServicePlans { get; set; }
        public WebServiceExecutionResult ExecutionResult { get; set; }
    }
}
