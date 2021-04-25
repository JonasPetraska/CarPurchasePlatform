using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPurchasePlatform.Models.Algorithms
{
    public class Rule
    {
        public Rule(PartnerSchema schema)
        {
            RightSide = schema.Outputs.Select(x => x.Name).ToList();
            LeftSide = schema.Inputs.Select(x => x.Name).ToList();
            PartnerType = schema.PartnerType;
        }

        public int NumberNumeric { get; set; }
        public string Number { get; set; }
        public IEnumerable<string> RightSide { get; set; }
        public IEnumerable<string> LeftSide { get; set; }

        //For FC
        public bool Flag1 { get; set; }
        public bool Flag2 { get; set; }

        //For reference
        public PartnerTypeEnum PartnerType { get; set; }

        public override string ToString()
        {
            return string.Join(",", LeftSide) + " -> " + string.Join(",", RightSide);
        }
    }
}
