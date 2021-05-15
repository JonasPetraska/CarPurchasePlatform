using CarPurchasePlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPurchasePlatform.Repositories
{
    public class InMemoryWebServiceSchemaRepository : IWebServiceSchemaRepository
    {
        public Task<Response<IEnumerable<WebServiceSchema>>> GetAsync()
        {
            return Task.FromResult(new Response<IEnumerable<WebServiceSchema>>(new List<WebServiceSchema>()
            {
                new WebServiceSchema()
                { 
                    WebServiceType = WebServiceTypeEnum.AutomobileSearch, 
                    Inputs = new List<SchemaInputOutput>()
                    { 
                        new SchemaInputOutput("Manufacturer", SchemaIOTypes.String),
                        new SchemaInputOutput("Model", SchemaIOTypes.String),
                        new SchemaInputOutput("Year", 1900, 2021)
                    },
                    Outputs = new List<SchemaInputOutput>()
                    {
                        new SchemaInputOutput("LicensePlate", "--- ---"),
                        new SchemaInputOutput("VIN", "-----------------"),
                        new SchemaInputOutput("Mileage", 0, 1000000),
                        new SchemaInputOutput("Price", 0, 1000000)
                    }
                },
                new WebServiceSchema()
                { 
                    WebServiceType = WebServiceTypeEnum.AutomobileHistory,
                    Inputs = new List<SchemaInputOutput>()
                    {
                        new SchemaInputOutput("VIN", "-----------------")
                    },
                    Outputs = new List<SchemaInputOutput>()
                    {
                        new SchemaInputOutput("OwnersCount", 1, 20),
                        new SchemaInputOutput("Country", "--")
                    }
                },
                new WebServiceSchema()
                { 
                    WebServiceType = WebServiceTypeEnum.Insurance,
                    Inputs = new List<SchemaInputOutput>()
                    {
                        new SchemaInputOutput("PersonalCode", "-----------"),
                        new SchemaInputOutput("LicensePlate", "--- ---")
                    },
                    Outputs = new List<SchemaInputOutput>()
                    {
                        new SchemaInputOutput("YearlyFee", 1, 2000)
                    }
                },
                new WebServiceSchema()
                { 
                    WebServiceType = WebServiceTypeEnum.Loan,
                    Inputs = new List<SchemaInputOutput>()
                    {
                        new SchemaInputOutput("PersonalCode", "-----------"),
                        new SchemaInputOutput("Price", 0, 1000000),
                        new SchemaInputOutput("MaxLoanPercentage", 5, 100)
                    },
                    Outputs = new List<SchemaInputOutput>()
                    {
                        new SchemaInputOutput("LoanMonthlyFee", 1, 2000),
                        new SchemaInputOutput("YearlyPercentageFee", 5, 100),
                        new SchemaInputOutput("TimeInYears", 1, 7)
                    }
                },
                new WebServiceSchema()
                {
                    WebServiceType = WebServiceTypeEnum.Lease,
                    Inputs = new List<SchemaInputOutput>()
                    {
                        new SchemaInputOutput("PersonalCode", "-----------"),
                        new SchemaInputOutput("Price", 0, 1000000),
                        new SchemaInputOutput("Period", 1, 7),
                        new SchemaInputOutput("InitialDepositPercentage", 10, 50),
                        new SchemaInputOutput("LeftOverPercentage", 0, 30)
                    },
                    Outputs = new List<SchemaInputOutput>()
                    {
                        new SchemaInputOutput("LeaseMonthlyFee", 1, 2000),
                        new SchemaInputOutput("InitialFee", 1, 100000),
                        new SchemaInputOutput("LeftOver", 1, 100000)
                    }
                },
                new WebServiceSchema()
                { 
                    WebServiceType = WebServiceTypeEnum.Registration,
                    Inputs = new List<SchemaInputOutput>()
                    {
                        new SchemaInputOutput("VIN", "-----------------")
                    },
                    Outputs = new List<SchemaInputOutput>()
                    {
                        new SchemaInputOutput("RegistrationFee", 1, 1000)
                    }
                }
            }));
        }

        public async Task<Response<WebServiceSchema>> GetAsync(WebServiceTypeEnum type)
        {
            var allSchemas = await GetAsync();
            if (allSchemas.ResponseType != ErrorTypeEnum.Success)
                return new Response<WebServiceSchema>(allSchemas.ErrorMessage, allSchemas.ResponseType);

            return new Response<WebServiceSchema>(allSchemas.Content.FirstOrDefault(x => x.WebServiceType == type));
        }
    }
}
