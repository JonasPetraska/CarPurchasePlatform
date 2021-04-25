using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPurchasePlatform.Models
{
    public class PartnerSchema
    {
        public PartnerTypeEnum PartnerType { get; set; }
        public IEnumerable<SchemaInputOutput> Inputs { get; set; }
        public IEnumerable<SchemaInputOutput> Outputs { get; set; }

        public string ToWSDLSchema()
        {
            return "";
        }

        public string ToJSONSchema()
        {
            return "";
        }
    }

    public class SchemaInputOutput
    {
        public SchemaInputOutput(string name, SchemaIOTypes type)
        {
            Name = name;
            Type = type;
        }

        public SchemaInputOutput(string name, int lengthRestriction)
        {
            Name = name;
            Type = SchemaIOTypes.String;
            LengthRestriction = lengthRestriction;
        }

        public SchemaInputOutput(string name, string formatRestriction)
        {
            Name = name;
            Type = SchemaIOTypes.String;
            FormatRestriction = formatRestriction;
        }

        public SchemaInputOutput(string name, SchemaIOTypes type, bool shouldBePositive)
        {
            Name = name;
            Type = type;
            IsPositive = shouldBePositive;
        }

        public SchemaInputOutput(string name, int min, int max)
        {
            Name = name;
            Min = min;
            Max = max;
            Type = SchemaIOTypes.Int;
        }

        public SchemaInputOutput(string name, double min, double max)
        {
            Name = name;
            Min = min;
            Max = max;
            Type = SchemaIOTypes.Float;
        }

        public string Name { get; private set; }
        public SchemaIOTypes Type { get; private set; }
        public int LengthRestriction { get; private set; }
        public string FormatRestriction { get; private set; }
        public bool IsPositive { get; private set; }
        public double Min { get; private set; }
        public double Max { get; private set; }
    }

    public enum SchemaIOTypes
    {
        ComplexObject,
        String,
        Int,
        Float
    }
}
