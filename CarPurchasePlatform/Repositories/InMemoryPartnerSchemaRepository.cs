using CarPurchasePlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPurchasePlatform.Repositories
{
    public class InMemoryPartnerSchemaRepository : IPartnerSchemaRepository
    {
        public Task<Response<IEnumerable<PartnerSchema>>> GetAsync()
        {
            return Task.FromResult(new Response<IEnumerable<PartnerSchema>>(new List<PartnerSchema>()
            {
                new PartnerSchema()
                { 
                    PartnerType = PartnerTypeEnum.AutomobileSearch, 
                    Inputs = new List<SchemaInputOutput>()
                    { 
                        new SchemaInputOutput("Manufacturer", SchemaIOTypes.String),
                        new SchemaInputOutput("Model", SchemaIOTypes.String),
                        new SchemaInputOutput("Year", 1900, 2021)
                    },
                    Outputs = new List<SchemaInputOutput>()
                    {
                        new SchemaInputOutput("License plate", "--- ---"),
                        new SchemaInputOutput("VIN", "-----------------"),
                        new SchemaInputOutput("Mileage", 0, 1000000),
                        new SchemaInputOutput("Price", 0, 1000000)
                    }
                },
                new PartnerSchema()
                { 
                    PartnerType = PartnerTypeEnum.AutomobileHistory,
                    Inputs = new List<SchemaInputOutput>()
                    {
                        new SchemaInputOutput("VIN", "-----------------")
                    },
                    Outputs = new List<SchemaInputOutput>()
                    {
                        new SchemaInputOutput("Owners count", 1, 20),
                        new SchemaInputOutput("Country", "--")
                    }
                },
                new PartnerSchema()
                { 
                    PartnerType = PartnerTypeEnum.Insurance,
                    Inputs = new List<SchemaInputOutput>()
                    {
                        new SchemaInputOutput("Personal code", "-----------"),
                        new SchemaInputOutput("License plate", "--- ---")
                    },
                    Outputs = new List<SchemaInputOutput>()
                    {
                        new SchemaInputOutput("Yearly fee", 1, 2000)
                    }
                },
                new PartnerSchema()
                { 
                    PartnerType = PartnerTypeEnum.Loan,
                    Inputs = new List<SchemaInputOutput>()
                    {
                        new SchemaInputOutput("Personal code", "-----------"),
                        new SchemaInputOutput("Price", 0, 1000000),
                        new SchemaInputOutput("Max Loan Percentage", 5, 100)
                    },
                    Outputs = new List<SchemaInputOutput>()
                    {
                        new SchemaInputOutput("Loan monthly fee", 1, 2000),
                        new SchemaInputOutput("Yearly percentage fee", 5, 100),
                        new SchemaInputOutput("Time in years", 1, 7)
                    }
                },
                new PartnerSchema()
                {
                    PartnerType = PartnerTypeEnum.Lease,
                    Inputs = new List<SchemaInputOutput>()
                    {
                        new SchemaInputOutput("Personal code", "-----------"),
                        new SchemaInputOutput("Price", 0, 1000000),
                        new SchemaInputOutput("Period", 1, 7),
                        new SchemaInputOutput("Initial deposit percentage", 10, 50),
                        new SchemaInputOutput("Left over percentage", 0, 30)
                    },
                    Outputs = new List<SchemaInputOutput>()
                    {
                        new SchemaInputOutput("Lease monthly fee", 1, 2000),
                        new SchemaInputOutput("Initial fee", 1, 100000),
                        new SchemaInputOutput("Left over", 1, 100000)
                    }
                },
                new PartnerSchema()
                { 
                    PartnerType = PartnerTypeEnum.Registration,
                    Inputs = new List<SchemaInputOutput>()
                    {
                        new SchemaInputOutput("VIN", "-----------------")
                    },
                    Outputs = new List<SchemaInputOutput>()
                    {
                        new SchemaInputOutput("Registration fee", 1, 1000)
                    }
                }
            }));
        }

        public async Task<Response<PartnerSchema>> GetAsync(PartnerTypeEnum type)
        {
            var allSchemas = await GetAsync();
            if (allSchemas.ResponseType != ErrorTypeEnum.Success)
                return new Response<PartnerSchema>(allSchemas.ErrorMessage, allSchemas.ResponseType);

            return new Response<PartnerSchema>(allSchemas.Content.FirstOrDefault(x => x.PartnerType == type));
        }
    }
}
