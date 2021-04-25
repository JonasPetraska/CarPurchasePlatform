using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarPurchasePlatform.Models
{
    public class Partner
    {
        [Key]
        public int Id { get; set; }
        public PartnerTypeEnum Type { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }

    public enum PartnerTypeEnum
    {
        AutomobileSearch,
        AutomobileHistory,
        Lease,
        Loan,
        Insurance,
        Registration
    }
}
