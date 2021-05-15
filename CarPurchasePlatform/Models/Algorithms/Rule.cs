using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPurchasePlatform.Models.Algorithms
{
    public class Rule
    {
        public Rule(WebServiceSchema schema)
        {
            RightSide = schema.Outputs.Select(x => x.Name).ToList();
            LeftSide = schema.Inputs.Select(x => x.Name).ToList();
            WebServiceType = schema.WebServiceType;
        }

        public int NumberNumeric { get; set; }
        public string Number { get; set; }
        public IEnumerable<string> RightSide { get; set; }
        public IEnumerable<string> LeftSide { get; set; }

        //For FC
        public bool Flag1 { get; set; }
        public bool Flag2 { get; set; }

        //For reference
        public WebServiceTypeEnum WebServiceType { get; set; }

        public override string ToString()
        {
            return string.Join(",", LeftSide) + " -> " + string.Join(",", RightSide);
        }
    }
}
