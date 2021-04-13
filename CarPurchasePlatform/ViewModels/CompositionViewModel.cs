using CarPurchasePlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPurchasePlatform.ViewModels
{
    public class CompositionViewModel
    {
        public IEnumerable<Manufacturer> Manufacturers { get; set; }
        public IEnumerable<Model> ManufacturerModels { get; set; }
        public IEnumerable<int> ModelYears { get; set; }

        public string SelectedManufacturerName { get; set; }
        public string SelectedModelName { get; set; }
        public int SelectedYear { get; set; }
        public string PersonalNumber { get; set; }
        public double MaxTotalPrice { get; set; }

        public bool IsInsuranceRequired { get; set; }
        public bool IsCarHistoryRequired { get; set; }
        public bool IsLoanRequired { get; set; }
        public bool IsRegistrationFeeCalculationRequired { get; set; }
    }
}
